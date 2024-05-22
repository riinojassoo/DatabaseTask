using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class AccessPermission
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [Range(1,10000)]
        public int PermissionNr { get; set; }

        [Required]
        public Guid EmployeeId { get; set; }

        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }

        [Required]
        public Guid JobId { get; set; }
        [ForeignKey("JobId")]
        public Job Job { get; set; }


        [DataType(DataType.Date)]
        public DateTime ValidSince { get; set; }

        [DataType(DataType.Date)]
        public DateTime? ValidUntil { get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }

        // Constructor to initialize properties
        public AccessPermission()
        {
            Employee = new Employee(); // Initialize Employee property
            Job = new Job();           // Initialize Job property
        }
    }
}

