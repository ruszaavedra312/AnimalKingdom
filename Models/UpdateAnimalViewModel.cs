using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace CRUD_Test.AnimalKindom.Models
{
    public class UpdateAnimalViewModel
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Species { get; set; }

        public string CareTaker { get; set; }

        public string? OriginatedPlace { get; set; }

        public string? OriginalOwner { get; set; }

        public DateTime DateAdded { get; set; }

        public IEnumerable<SelectListItem>? SpeciesList { get; set; }
    }
}
