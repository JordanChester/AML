using AML.Server.Models;

namespace AML.Server.Interfaces
{
    public interface IMediaRepository
    {
        Task<List<Media>> SearchMedia(string searchTerm);
    }
}
