namespace AML.Server.Interfaces
{
    public interface IOrderRepository
    {
        Task ReserveMedia(int mediaId, int accountId);
        Task BorrowMedia(int mediaId, int accountId, DateTime returnDate);
        Task ReturnMedia(int mediaId, int accountId, DateTime dateReturned);
    }
}
