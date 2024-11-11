namespace AML.Server.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int AccountId { get; set; }
        public int MediaId { get; set; }
        public OrderType OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ReturnDate { get; set; }

        public OrderModel(int orderId, int accountId, int mediaId, OrderType orderType, DateTime orderDate, DateTime returnDate)
        {
            OrderId = orderId;
            AccountId = accountId;
            MediaId = mediaId;
            OrderType = orderType;
            OrderDate = orderDate;
            ReturnDate = returnDate;
        }
    }
}
