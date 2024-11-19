using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AML.Server.Models
{
    public class MediaStock
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [ForeignKey(nameof(Media.Id))]
        public int MediaId { get; set; }
        [ForeignKey(nameof(Branch.Id))]
        public int BranchId { get; set; }
        [Required]
        public int AvailableStock { get; set; }

    }
}
