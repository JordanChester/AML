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

        public MediaController(IMediaRepository mediaRepository)
        {
            this._mediaRepository = mediaRepository;
        }

        [HttpGet]
        [Route("search-media")]
        public async Task<List<Media>> SearchMedia(/*Request Object*/)
        {
            // Logic going to repo & return results
            List<Media> results = new List<Media>();
            return results;
        }
    }
}
