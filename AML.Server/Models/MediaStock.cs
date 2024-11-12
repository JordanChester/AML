using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AML.Server.Models
{
    public class MediaStock
    {
        [Key]
        public int MediaStockId { get; set; }
        [ForeignKey(nameof(Media.MediaId))]
        public int MediaId { get; set; }
        [ForeignKey(nameof(Branch.BranchId))]
        public int BranchId { get; set; }
        [Required]
        public int AvailableStock { get; set; }

    }
}
