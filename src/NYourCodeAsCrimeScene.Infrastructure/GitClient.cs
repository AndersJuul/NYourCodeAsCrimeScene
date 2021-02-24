using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class GitClient : IGitClient
    {
        private const string gitPath = @"C:\Users\ajf_aj\AppData\Local\Atlassian\SourceTree\git_local\cmd\git.exe";
        private readonly ILogger<GitClient> _logger;
        private readonly IMediator _mediator;

        public GitClient(IMediator mediator, ILogger<GitClient> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IEnumerable<CommitDto>> GetCommits(string projectName, string projectPath, string[] fileExt)
        {
            _logger.LogInformation("Getting commits from " + projectPath);
            var output = await GetResultOfexecutingGit(projectPath, "log --date=iso");

            var result = await _mediator.Send(new CommitQuery(output.Split("\n")));

            return result;
        }

        public async Task<IEnumerable<FileDto>> GetFiles(string projectPath, string commitId)
        {
            _logger.LogInformation("Getting files from commit: " + commitId);
            var output = await GetResultOfexecutingGit(projectPath, "diff-tree --root --no-commit-id --name-only -r "+commitId);

            var result = await _mediator.Send(new GitFileQuery(output.Split("\n")));

            return result;
        }

        private static async Task<string> GetResultOfexecutingGit(string projectPath, string arguments)
        {
            var process = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = projectPath,
                    FileName = gitPath,
                    Arguments = arguments,
                    UseShellExecute = false,
                    RedirectStandardOutput = true
                }
            };
            process.Start();
            var output = await process.StandardOutput.ReadToEndAsync();
            await process.WaitForExitAsync();

            if (process.ExitCode != 0)
                throw new InvalidOperationException(process.ExitCode.ToString());
            return output;
        }
    }
}