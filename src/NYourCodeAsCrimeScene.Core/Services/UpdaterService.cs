using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Core.Entities;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Core.Specifications;
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
                var project= projects.SingleOrDefault();
                if (project==null)
                {
                    project = new Project(projectName, projectPath);
                    await _repository.AddAsync(project);
                }

                var commits = await _gitClient
                    .GetCommits(projectName, projectPath, new[] { "cs" });

                foreach (var commitDto in commits)
                {
                    if (!project.HasCommit(commitDto.CommitId))
                    {
                        project.AddCommit(new Commit( commitDto.CommitId, commitDto.Date));
                    }
                }

                await _unitOfWork.CommitChanges();
            }
            catch (Exception e)
            {
                _logger.LogError(e, "During Update");
                throw;
            }
        }
    }
}