using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class Hints
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Hint { get; set; }

        [Range(0, 10000)]
        public int HintId { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        // Foreign key property
        public Guid? FirmId { get; set; }

        // Navigation property
        [ForeignKey("FirmId")]
        public Firm Firm { get; set; }
    }
}
