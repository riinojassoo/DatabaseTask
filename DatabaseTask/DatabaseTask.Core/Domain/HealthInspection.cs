using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class HealthInspection
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [DataType(DataType.Date)]
        public DateTime LastInspection { get; set; }

        [DataType(DataType.Date)]
        public DateTime NewInspectionDue { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }
    }
}

