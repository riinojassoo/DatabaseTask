using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseTask.Core.Domain
{
    public class Requests
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [StringLength(255)]
        public string Request { get; set; }

        [Required]
        [Range(1,1000)]
        public int RequestId { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }
    }
}

