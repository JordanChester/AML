using System.ComponentModel.DataAnnotations;

namespace AML.Server.Models
{
    public class Branch
    {
        [Key]
        public int BranchId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }

    }
}
