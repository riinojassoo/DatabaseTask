using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class Job
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        [StringLength(255)]
        public string Title { get; set; }

        [Required]
        [StringLength(255)]
        public string Unit { get; set; }

        [Required]
        [Range(1, 1000)]
        public int Code { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        public ICollection<AccessPermission> AccessPermissions { get; set; } = new List<AccessPermission>();
        public ICollection<WorkingHistory> WorkingHistory { get; set; } = new List<WorkingHistory>();
    }
}
