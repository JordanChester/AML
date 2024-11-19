using AML.Server.Business.Media;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ISearchMediaGetter _searchMediaGetter;

        public MediaController(IMediaRepository mediaRepository,
            ISearchMediaGetter searchMediaGetter)
        {
            this._mediaRepository = mediaRepository;
            this._searchMediaGetter = searchMediaGetter;
        }

        [HttpGet]
        public async Task<List<Media>> SearchMedia(SearchMediaRequest? request)
        {
            var results = await this._searchMediaGetter.Get(request);
            return results;
        }
    }
}
