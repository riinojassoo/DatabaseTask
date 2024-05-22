using System.ComponentModel.DataAnnotations;


namespace DatabaseTask.Core.Domain
{
    public class Firm
    {
        [Key]
        public Guid Id { get; set; }


        [Required]
        [StringLength(255)]
        public string RegistryType { get; set; }

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
        public ICollection<Hints> Hints { get; set; } = new List<Hints>();
        public ICollection<BranchOffice> BranchOffices { get; set; } = new List<BranchOffice>();
    }
}
