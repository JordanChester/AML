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
        public async Task<List<MediaModel>> SearchMedia(/*Request Object*/)
        {
            // Logic going to repo & return results
            List<MediaModel> results = new List<MediaModel>();
            return results;
        }
    }
}
