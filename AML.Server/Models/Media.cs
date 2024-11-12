using System.ComponentModel.DataAnnotations;

namespace AML.Server.Models
{
    public class Media
    {
        [Key]
        public int MediaId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public float Price { get; set; }
        [Required]
        public bool Available { get; set; }
        [Required]
        public MediaType MediaType { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
