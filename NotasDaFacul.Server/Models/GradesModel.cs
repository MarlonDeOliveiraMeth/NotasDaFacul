using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace NotasDaFacul.Server.Models
{
    public class GradesModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [StringLength(100)]
        public string? Course { get; set; }

        [Required]
        [Column(TypeName = "decimal(3, 1)")]
        [Range(0.0, 10.0)]
        public decimal Grade { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Date { get; set; }
    }
}
