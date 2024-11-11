namespace AML.Server.Interfaces
{
    public interface IStockRepository
    {
        Task GetStockForBranch(int branchId, int mediaId, int amount);
        Task RemoveMedia(int branchId, int mediaId);
    }
}
