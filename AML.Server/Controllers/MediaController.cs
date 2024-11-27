using AML.Server.Business.Media;
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
        private readonly IMediaRepository _mediaRepository;
        private readonly ISearchMediaGetter _searchMediaGetter;
        private readonly IBorrowMediaProcessor _borrowMediaProcessor;

        public MediaController(IMediaRepository mediaRepository,
            ISearchMediaGetter searchMediaGetter,
            IBorrowMediaProcessor borrowMediaProcessor)
        {
            this._mediaRepository = mediaRepository;
            this._searchMediaGetter = searchMediaGetter;
            _borrowMediaProcessor = borrowMediaProcessor;
        }

        [HttpPost]
        [Route("search-media")]
        public async Task<List<Media>> SearchMedia(SearchMediaRequest? request)
        {
            var results = await this._searchMediaGetter.Get(request);
            return results;
        }

        [HttpPost]
        [Route("borrow-media")]
        public async Task<bool> BorrowMedia(BorrowMediaRequest request)
        {
            try
            {
                await _borrowMediaProcessor.Process(request);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
