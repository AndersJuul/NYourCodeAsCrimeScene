using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NYourCodeAsCrimeScene.Infrastructure;
using Xunit;

namespace NYourCodeAsCrimeScene.UnitTests.Infrastructure
{
    public class CommitQueryHandlerMapsToCommitDtos
    {
        [Fact]
        public async Task ReturnsCommitDtosFromStringArray()
        {
            var sut = new CommitQueryHandler();

            var strings =   @"commit 8a3c8bb100372dd1ed194c3d66b9d81da54b50e1
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 15:45:22 +0100

    .

commit 38b1c1bdb664057ae9e70d3b38be89436259d657
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 15:31:40 +0100

    .

commit 64511abcc3bca58f751357ce12cd8d117fc2dfe5
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 14:44:25 +0100

    .

commit 085a4bfed4f306cece75fa4570b865a84a37720d
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 12:13:33 +0100

    Template changed to use local sqlserver (from sqllite)

commit a69701b6817c437c6146179f9b70e3de1e40b085
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 12:02:41 +0100

    initial

commit 7ce03f918f5dd012d6b8ee5a5038e1f05c12ca6b
Author: Anders Juul <andersjuulsfirma@gmail.com>
Date:   2021-02-07 11:42:33 +0100

    Initial commit
".Split("\r\n");

            var result = await sut.Handle(new CommitQuery(strings), CancellationToken.None);

            Assert.Equal(6, result.Count());
        }
    }
}