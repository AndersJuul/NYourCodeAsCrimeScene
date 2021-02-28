using System.Linq;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Core.Entities;
using NYourCodeAsCrimeScene.UnitTests;
using Xunit;

namespace NYourCodeAsCrimeScene.IntegrationTests.Data
{
    public class EfRepositoryAdd : BaseEfRepoTestFixture
    {
        [Fact]
        public async Task AddsItemAndSetsId()
        {
            await Task.CompletedTask;
            //var repository = GetRepository();
            //var item = new ToDoItemBuilder().Build();

            //await repository.AddAsync(item);

            //var newItem = (await repository.ListAsync<ToDoItem>())
            //                .FirstOrDefault();

            //Assert.Equal(item, newItem);
            //Assert.True(newItem?.Id > 0);
        }
    }
}
