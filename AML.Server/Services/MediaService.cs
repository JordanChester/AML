using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Services
{
    public class MediaService
    {
        private readonly IMediaRepository _mediaRepository;

        public MediaService(IMediaRepository mediaRepository)
        {
            this._mediaRepository = mediaRepository;
        }

        public async Task<List<Media>> GetMedia(SearchMediaRequest? request)
        {
            var results = await this._mediaRepository.GetMedia(request);
            return results;
        }

        public async Task<bool> BorrowMedia(BorrowMediaRequest request)
        {
            try
            {
                await _mediaRepository.BorrowMedia(request);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
