using Ardalis.Specification;
using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.Core.Specifications
{
    public sealed class ProjectByNameSpec : Specification<Project>
    {
        public ProjectByNameSpec(string projectName)
        {
            Query.Where(item => item.Name==projectName);
        }
    }
}
