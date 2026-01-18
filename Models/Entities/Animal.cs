using System.ComponentModel.DataAnnotations;

namespace CRUD_Test.AnimalKindom.Models.Entities
{
    public class Animal
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();
        
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        public string Species { get; set; }

        [Required]
        public string CareTaker { get; set; }

        [Required]
        public DateTime DateAdded { get; set; } = DateTime.UtcNow;

        public string? OriginatedPlace { get; set; }

        public string? OriginalOwner { get; set; }
    }
}
