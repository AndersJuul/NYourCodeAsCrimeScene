using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Interfaces;
using NYourCodeAsCrimeScene.Infrastructure.Data;

namespace NYourCodeAsCrimeScene.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CommitChanges()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}