using Ardalis.Specification;
using NYourCodeAsCrimeScene.Core.Entities;

namespace NYourCodeAsCrimeScene.Core.Specifications
{
    public class IncompleteItemsSpecification : Specification<ToDoItem>
    {
        public IncompleteItemsSpecification()
        {
            Query.Where(item => !item.IsDone);
        }
    }
}
