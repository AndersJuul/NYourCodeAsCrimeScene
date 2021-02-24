using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NYourCodeAsCrimeScene.Core.Services;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class CommitQueryHandler : IRequestHandler<CommitQuery, IEnumerable<CommitDto>>
    {
        public async Task<IEnumerable<CommitDto>> Handle(CommitQuery request, CancellationToken cancellationToken)
        {
            await Task.CompletedTask;

            var result = new List<CommitDto>();
            
            var output = request.Output;

            while (output.Any())
            {
                while (output.Any() && !(output.FirstOrDefault()?.StartsWith("commit") ?? false))
                    output = output.Skip(1).ToArray();
                if (!output.Any())
                    break;

                var commit = output.First();
                output = output.Skip(1).ToArray();
                var author = output.First().Substring("Author: ".Length);
                output = output.Skip(1).ToArray();
                var date = output.First().Substring("Date : ".Length);

                result.Add(new CommitDto
                {
                    CommitId = commit,
                    Date = Convert.ToDateTime(date.Trim()),
                    Author = author
                });
            }

            return result;
        }
    }
    public class CommitQuery : IRequest<IEnumerable<CommitDto>>
    {
        public string[] Output { get; }

        public CommitQuery(string[] output)
        {
            Output = output;
        }
    }
}