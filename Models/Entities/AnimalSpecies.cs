using System.ComponentModel.DataAnnotations;

namespace CRUD_Test.AnimalKindom.Models.Entities
{
    public class AnimalSpecies
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string SpeciesName { get; set; }
    }
}
