using System;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NYourCodeAsCrimeScene.Infrastructure.Data;
using NYourCodeAsCrimeScene.Web;
using Xunit;

namespace NYourCodeAsCrimeScene.IntegrationTests.Infrastructure
{
    public class GitClientGetCommits : BaseGitClientTestFixture
    {
        [Fact]
        public async Task ReturnsExpectedNumberOfCommits()
        {
            var gitClient = GetGitClient();

            var commitDtos = await gitClient.GetCommits(
                projectName: "NYourCodeAsCrimeScene",
                projectPath: @"C:\Projects\NYourCodeAsCrimeScene", 
                new[] {""});
            Assert.Equal(3, commitDtos.Count());
        }

        [Fact]
        public async Task Aa()
        {
        }
    }
}