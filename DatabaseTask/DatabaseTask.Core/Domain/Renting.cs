using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class Renting
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [Required]
        public Guid ObjectId { get; set; }

        [ForeignKey("ObjectId")]
        public Objects Object { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }
    }
}

