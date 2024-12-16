using AML.Server.Controllers;
using AML.Server.Interfaces;
using AML.Server.Models;
using Autofac.Extras.Moq;
using Moq;

namespace AMLTests.Controllers
{
    public class BranchControllerTests
    {
        [Fact]
        public async Task GetBranchesReturnsList()
        {
            var branches = new List<Branch>()
            {
                new Branch
                {
                    Id = 0,
                    Name = "null",
                    Location = "null"
                }
            };

            using (var mock = AutoMock.GetLoose())
            {
                mock.Mock<IBranchRepository>()
                    .Setup(x => x.GetBranches())
                    .ReturnsAsync(branches);

                var cls = mock.Create<BranchController>();
                var result = await cls.GetBranches();

                Assert.NotNull(result);
            }
        }
    }
}
