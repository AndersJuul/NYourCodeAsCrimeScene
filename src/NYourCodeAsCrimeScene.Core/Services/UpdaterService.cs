using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NYourCodeAsCrimeScene.Core.Entities;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Core.Specifications;
using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Services
{
    public class UpdaterService : IUpdaterService
    {
        private readonly IGitClient _gitClient;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<UpdaterService> _logger;
        private readonly IRepository _repository;

        public UpdaterService(IGitClient gitClient, IUnitOfWork unitOfWork, ILogger<UpdaterService> logger, IRepository repository)
        {
            _gitClient = gitClient;
            _unitOfWork = unitOfWork;
            _logger = logger;
            _repository = repository;
        }
        
        public async Task Update(string projectName, string projectPath)
        {
            try
            {
                var projects = await _repository.ListAsync(new ProjectByNameSpec(projectName));
                var project = projects.SingleOrDefault();
                if (project==null)
                {
                    project = new Project(projectName, projectPath);
                    await _repository.AddAsync(project);
                }

                var commits = await _gitClient
                    .GetCommits(projectName, projectPath, new[] { "cs" });

                foreach (var commitDto in commits)
                {
                    var commit = project.CommitById(commitDto.CommitId);
                    if (commit==null)
                    {
                        commit = new GitCommit( commitDto.CommitId, commitDto.Date);
                        project.AddCommit(commit);
                    }

                    if (!commit.GitFiles.Any())
                    {
                        var fileDtos = await _gitClient
                            .GetFiles(projectPath, commit.CommitId);
                        foreach (var fileDto in fileDtos)
                        {
                            try
                            {
                                var fileContent = await _gitClient.GetFileContent(projectPath, commit.CommitId, fileDto.Name);
                                commit.AddFile(new GitFile(fileDto.Name, fileContent.Count()));
                            }
                            catch (Exception e)
                            {
                                _logger.LogWarning("Exception during file content retrieval. File not added to commit: "+fileDto.Name);
                            }
                        }
                    }
                }

                _logger.LogInformation("Project: " + JsonConvert.SerializeObject( new Analyzer(project).GetTop(5),Formatting.Indented));
                
                await _unitOfWork.CommitChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "During Update");
                throw;
            }
        }
    }

    public class Analyzer
    {
        private Project _project;

        public Analyzer(Project project)
        {
            _project = project;
        }

        public CodeIssue[] GetTop(int count)
        {
            return new[] {new CodeIssue()};
        }
    }

    public class CodeIssue:ValueObject
    {
    }
}