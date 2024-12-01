using AML.Server.Business.Media;
using AML.Server.Data;
using AML.Server.Models;
using EntityFrameworkCore3Mock;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace AMLTests.Business.Media;

public class SearchMediaGetterTests
{
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
        
        
        SearchMediaGetter getter = new SearchMediaGetter(dbContextMock.Object);
        var result = await getter.Get(request);
        
        Assert.NotNull(result);
        Assert.Equal(0, result[0].Id);
    }
}