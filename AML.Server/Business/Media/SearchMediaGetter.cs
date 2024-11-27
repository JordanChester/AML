using AML.Server.Data;
using AML.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AML.Server.Business.Media;

public class SearchMediaGetter : ISearchMediaGetter
{
    private readonly DBContext dbContext;
    
    public SearchMediaGetter(DBContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<Models.Media>> Get(SearchMediaRequest? request)
    {
        var mediaList = new List<Models.Media>();
        
        if (request.Search is null)
        {
            mediaList = await this.dbContext.Media.ToListAsync();
        }
        else
        {
            mediaList = await this.dbContext.Media.Where(x => x.Name.ToLower().Trim().Contains(request.Search.ToLower().Trim())).ToListAsync();    
        }
        
        return mediaList;
    }
}