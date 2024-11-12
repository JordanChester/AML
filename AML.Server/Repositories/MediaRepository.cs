using AML.Server.Interfaces;
using AML.Server.Models;

namespace AML.Server.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        // Add a dbcontext here

        public MediaRepository(/*inject dbcontext*/)
        {
            /*Assign injected context to declared above*/
        }

        public async Task<List<Media>> SearchMedia(string searchTerm)
        {
            // add logic
            return null;
        }
    }
}
