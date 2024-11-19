using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AML.Server.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(Account.Id))]
        public int AccountId { get; set; }
        [ForeignKey(nameof(Media.Id))]
        public int MediaId { get; set; }
        [Required]
        public OrderType OrderType { get; set; }
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }

    }
}
