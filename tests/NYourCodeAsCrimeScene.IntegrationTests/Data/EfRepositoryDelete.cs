﻿//using System;
//using System.Threading.Tasks;
//using NYourCodeAsCrimeScene.Core.Entities;
//using NYourCodeAsCrimeScene.UnitTests;
//using Xunit;

//namespace NYourCodeAsCrimeScene.IntegrationTests.Data
//{
//    public class EfRepositoryDelete : BaseEfRepoTestFixture
//    {
//        [Fact]
//        public async Task DeletesItemAfterAddingIt()
//        {
//            // add an item
//            var repository = GetRepository();
//            var initialTitle = Guid.NewGuid().ToString();
//            var item = new ToDoItemBuilder().Title(initialTitle).Build();
//            await repository.AddAsync(item);

//            // delete the item
//            await repository.DeleteAsync(item);

//            // verify it's no longer there
//            Assert.DoesNotContain(await repository.ListAsync<ToDoItem>(),
//                i => i.Title == initialTitle);
//        }
//    }
//}
