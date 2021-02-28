using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class GitFileQueryHandler : IRequestHandler<GitFileQuery, FileDto[]>
    {
        public async Task<FileDto[]> Handle(GitFileQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var result = new List<FileDto>();
            
            var output = request.Output.Where(x=> !string.IsNullOrEmpty(x));

            foreach (var fileName in output)
            {
                result.Add(new FileDto{Name = fileName});
            }

            return result.ToArray();
        }
    }
    public class GitFileQuery : IRequest<FileDto[]>
    {
        public string[] Output { get; }

        public GitFileQuery(string[] output)
        {
            Output = output;
        }
    }
}