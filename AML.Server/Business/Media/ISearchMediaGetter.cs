using AML.Server.Models;

namespace AML.Server.Business.Media;

public interface ISearchMediaGetter
{
    Task<List<Models.Media>> Get(SearchMediaRequest? request);
}