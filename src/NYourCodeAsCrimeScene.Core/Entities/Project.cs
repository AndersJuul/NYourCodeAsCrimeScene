using NYourCodeAsCrimeScene.SharedKernel;
using NYourCodeAsCrimeScene.SharedKernel.Interfaces;

namespace NYourCodeAsCrimeScene.Core.Entities
{
    public class Project : BaseEntity, IAggregateRoot
    {
        public string Name { get; set; }
    }
}