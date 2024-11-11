using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IMediaRepository
    {
        Task<List<MediaModel>> SearchMedia(string searchTerm);
    }
}
