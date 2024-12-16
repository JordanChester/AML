using AML.Server.Controllers;
using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;
using Autofac.Extras.Moq;
using Moq;

namespace AMLTests.Controllers;

public class MediaControllerTests
{
    [Fact]
    public async Task SearchMediaReturnsList()
    {
        var mediaList = new List<Media>()
        {
            new Media
            {
                Id = 0,
                Name = "null",
                Price = 0,
                Available = true,
                MediaType = MediaType.Film,
                Description = "null"
            }
        };

        var request = new SearchMediaRequest
        {
            Search = "null"
        };

        using (var mock = AutoMock.GetLoose())
        {
            mock.Mock<IMediaRepository>()
                .Setup(x => x.GetMedia(request))
                .ReturnsAsync(mediaList);

            var cls = mock.Create<MediaController>();
            var result = await cls.SearchMedia(request);
            
            Assert.NotNull(result);
        }
    }

    [Fact]
    public async Task BorrowMediaReturnsTrue()
    {
        var request = new BorrowMediaRequest
        {
            AccountId = 0,
            MediaId = 0,
            Start = DateTime.Now,
            End = DateTime.Now.AddDays(2)
        };

        using (var mock = AutoMock.GetLoose())
        {
            mock.Mock<IMediaRepository>()
                .Setup(x => x.BorrowMedia(request));
            
            var cls = mock.Create<MediaController>();
            var result = await cls.BorrowMedia(request);
            
            Assert.True(result);
        }
    }
}