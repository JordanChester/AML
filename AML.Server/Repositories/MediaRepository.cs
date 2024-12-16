using AML.Server.Data;
using AML.Server.DTOs;
using AML.Server.Interfaces;
using AML.Server.Models;
using Microsoft.EntityFrameworkCore;

namespace AML.Server.Repositories
{
    public class MediaRepository : IMediaRepository
    {
        private readonly DBContext dbContext;

        public MediaRepository(DBContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Models.Media>> GetMedia(SearchMediaRequest? request)
        {
            var mediaList = new List<Models.Media>();

            if (request.Search is null)
            {
                mediaList = await this.dbContext.Media.ToListAsync();
            }
            else
            {
                mediaList = await this.dbContext.Media.Where(x => x.Name.ToLower().Trim().Contains(request.Search.ToLower().Trim())).ToListAsync();
            }

            return mediaList;
        }

        public async Task BorrowMedia(BorrowMediaRequest request)
        {
            var order = new Order()
            {
                AccountId = request.AccountId,
                MediaId = request.MediaId,
                OrderDate = request.Start,
                ReturnDate = request.End,
                OrderType = OrderType.Borrow
            };

            this.dbContext.Orders.Add(order);
            await this.dbContext.SaveChangesAsync();
        }
    }
}
