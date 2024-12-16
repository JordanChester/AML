using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.AspNetCore.Mvc;

namespace AML.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            this._mediaService = mediaService;
        }

        [HttpPost]
        [Route("search-media")]
        public async Task<List<Media>> SearchMedia(SearchMediaRequest? request)
        {
            return await this._mediaService.GetMedia(request);
        }

        [HttpPost]
        [Route("borrow-media")]
        public async Task<bool> BorrowMedia(BorrowMediaRequest request)
        {
            return await _mediaService.BorrowMedia(request);
        }
    }
}
