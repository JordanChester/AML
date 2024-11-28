using AML.Server.Data;
using AML.Server.DTOs;
using AML.Server.Models;

namespace AML.Server.Business.Media;

public class BorrowMediaProcessor : IBorrowMediaProcessor
{
    private readonly DBContext dbContext;

    public BorrowMediaProcessor(DBContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task Process(BorrowMediaRequest request)
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