using System.ComponentModel.DataAnnotations;

namespace DatabaseTask.Core.Domain
{
    public class Objects
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public Guid ObjectId { get; set; }

        [StringLength(255)]
        public string ObjectLocation { get; set; }

        [DataType(DataType.Date)]
        public DateTime PurchasingDate { get; set; }

        [StringLength(255)]
        public string History {  get; set; }

        [StringLength(255)]
        public string? Comment { get; set; }


        public ICollection<Renting> Renting { get; set; } = new List<Renting>();

    }
}

