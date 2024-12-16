using AML.Server.DTOs;
using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IMediaService
    {
        Task<List<Media>> GetMedia(SearchMediaRequest? request);
        Task<bool> BorrowMedia(BorrowMediaRequest request);
    }
}
