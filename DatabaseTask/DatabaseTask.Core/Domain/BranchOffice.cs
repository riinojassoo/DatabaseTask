using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DatabaseTask.Core.Domain
{
    public class BranchOffice
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        [StringLength(255)]
        public string ContactPerson { get; set; }

        [Range(100000000000000, 999999999999999)]
        public long ContactPhone { get; set; }


        [StringLength(255)]
        public string EmailAddress { get; set; }


        [StringLength(255)]
        public string? Comment { get; set; }


        // Foreign key property
        public Guid? FirmId { get; set; }

        // Navigation property
        [ForeignKey("FirmId")]
        public Firm Firm { get; set; }

        public ICollection<Employee> Employees { get; set; } = new List<Employee>();
    }
}
