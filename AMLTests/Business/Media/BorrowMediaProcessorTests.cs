using AML.Server.Business.Media;
using AML.Server.Data;
using AML.Server.DTOs;
using AML.Server.Models;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace AMLTests.Business.Media;

public class BorrowMediaProcessorTests
{
    [Fact]
    public async Task BorrowMediaProcessorOrdersMedia()
    {
        var request = new BorrowMediaRequest
        {
            AccountId = 0,
            MediaId = 0,
            Start = DateTime.Now,
            End = DateTime.Now.AddHours(1),
        };
        
        var mockSetOrder = new Mock<DbSet<Order>>();
        var mockContext = new Mock<DBContext>();
        mockContext.Setup(x => x.Orders).Returns(mockSetOrder.Object);
        
        BorrowMediaProcessor processor = new BorrowMediaProcessor(mockContext.Object);
        await processor.Process(request);
        
        // var dbContextMock = new DbContextMock<DBContext>();
        // dbContextMock.Setup<DbSet<Order>>(x => x.Orders).ReturnsDbSet(new List<Order>()).Verifiable();
        //
        // BorrowMediaProcessor processor = new BorrowMediaProcessor(dbContextMock.Object);
        // await processor.Process(request);
        
        //mockContext.Verify(x => x.Add(It.IsAny<Order>())); 
    }
}