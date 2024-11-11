namespace AML.Server.Models
{
    public class MediaStockModel
    {
        public int MediaStockId { get; set; }
        public int MediaId { get; set; }
        public int BranchId { get; set; }
        public int AvailableStock { get; set; }

        public MediaStockModel(int mediaStockId, int mediaId, int branchId, int availableStock)
        {
            MediaStockId = mediaStockId;
            MediaId = mediaId;
            BranchId = branchId;
            AvailableStock = availableStock;
        }
    }
}
