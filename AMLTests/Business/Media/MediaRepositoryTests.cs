using AML.Server.Data;
using AML.Server.DTOs;
using AML.Server.Models;
using AML.Server.Repositories;
using EntityFrameworkCore3Mock;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;

namespace AMLTests.Business.Media
{
    public class MediaRepositoryTests
    {
        [Fact]
        public async Task BorrowMediaProcessorOrdersMedia()
        {
            var request = new BorrowMediaRequest
            {
                AccountId = 0,
                MediaId = 0,
                Start = DateTime.Now,
                End = DateTime.Now.AddHours(1),
            };

            var mockSetOrder = new Mock<DbSet<Order>>();
            var mockContext = new Mock<DBContext>();
            mockContext.Setup(x => x.Orders).Returns(mockSetOrder.Object);

            MediaRepository repo = new MediaRepository(mockContext.Object);
            await repo.BorrowMedia(request);
        }

        [Fact]
        public async Task SearchMediaGetterReturnsListOfMedia()
        {
            var request = new SearchMediaRequest
            {
                Search = "null"
            };

            var mediaList = new List<AML.Server.Models.Media>()
        {
            new AML.Server.Models.Media
            {
                Id = 0,
                Name = "null",
                Price = 0,
                Available = true,
                MediaType = MediaType.Film,
                Description = "null"
            },
            new AML.Server.Models.Media
            {
                Id = 1,
                Name = "null1",
                Price = 0,
                Available = true,
                MediaType = MediaType.Film,
                Description = "null"
            }
        };

            var dbContextMock = new DbContextMock<DBContext>();
            dbContextMock.Setup<DbSet<AML.Server.Models.Media>>(x => x.Media)
                .ReturnsDbSet(mediaList);


            MediaRepository repo = new MediaRepository(dbContextMock.Object);
            var result = await repo.GetMedia(request);

            Assert.NotNull(result);
            Assert.Equal(0, result[0].Id);
        }
    }
}
