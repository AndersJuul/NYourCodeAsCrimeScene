using System.Threading.Tasks;

namespace NYourCodeAsCrimeScene.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task CommitChanges();
    }
}