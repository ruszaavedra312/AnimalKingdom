using System.ComponentModel.DataAnnotations;

namespace CRUD_Test.AnimalKindom.Models
{
    public class AddViewModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public int Age { get; set; }

        [Required]
        public string Species { get; set; }
        public string CareTaker { get; set; }
    }
}
