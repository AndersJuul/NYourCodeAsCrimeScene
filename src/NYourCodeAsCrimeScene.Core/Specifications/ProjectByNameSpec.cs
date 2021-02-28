using System;
using System.Linq.Expressions;
using Ardalis.Specification;
using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.Core.Specifications
{
    public sealed class ProjectByNameSpec : BaseProjectSpec
    {
        public ProjectByNameSpec(string projectName) :
            base(item => item.Name == projectName)
        {
        }
    }

    public sealed class AllProjects : BaseProjectSpec
    {
        public AllProjects()
            : base(x => true)
        {
        }
    }

    public class BaseProjectSpec : Specification<Project>
    {
        protected BaseProjectSpec(Expression<Func<Project, bool>> expression)
        {
            Query
                .Where(expression)
                .Include(x => x.Commits)
                .ThenInclude(xx=>xx.GitFiles)
                .ThenInclude(xxx=>xxx.GitFileEntries);
        }
    }
}