using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class GitFileQueryHandler : IRequestHandler<GitFileQuery, IEnumerable<FileDto>>
    {
        public async Task<IEnumerable<FileDto>> Handle(GitFileQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var result = new List<FileDto>();
            
            var output = request.Output.Where(x=> !string.IsNullOrEmpty(x));

            foreach (var fileName in output)
            {
                result.Add(new FileDto{Name = fileName});
            }

            return result;
        }
    }
    public class GitFileQuery : IRequest<IEnumerable<FileDto>>
    {
        public string[] Output { get; }

        public GitFileQuery(string[] output)
        {
            Output = output;
        }
    }
}