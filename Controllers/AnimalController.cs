using Microsoft.AspNetCore.Mvc;
using CRUD_Test.AnimalKindom.Models;
using CRUD_Test.AnimalKindom.Data;
using CRUD_Test.AnimalKindom.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CRUD_Test.AnimalKindom.Controllers
{
    public class AnimalController : Controller
    {
        private readonly AppDbContext dbcontext; // Inject database context

        public AnimalController(AppDbContext context)
        {
            dbcontext = context;
        }

        [HttpGet]
        // public IActionResult Create()
        // {
        //     return View();
        // }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var viewModel = new AddViewModel
            {
                SpeciesList = await dbcontext.AnimalSpecies
                    .Select(s => new SelectListItem
                    {
                        Value = s.SpeciesName,
                        Text = s.SpeciesName
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }

        
        // For Create or Inserting Data 
        [HttpPost]
        public async Task<IActionResult> Create(AddViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.SpeciesList = await dbcontext.AnimalSpecies
                    .Select(s => new SelectListItem
                    {
                        Value = s.SpeciesName,
                        Text = s.SpeciesName
                    })
                    .ToListAsync();

                return View(viewModel);
            }

            var newAnimal = new Animal
            {
                Name = viewModel.Name,
                Age = viewModel.Age,
                Species = viewModel.Species,
                CareTaker = viewModel.CareTaker,
                OriginatedPlace = viewModel.OriginatedPlace,
                OriginalOwner = viewModel.OriginalOwner
            };

            await dbcontext.Animals.AddAsync(newAnimal);
            await dbcontext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Added successfully!";

            return RedirectToAction("Read");
        }



        // For Read or Retrieving Data 
        [HttpGet]
        public async Task <IActionResult> Read()
        {
            var animals = await dbcontext.Animals.ToListAsync();

            return View(animals);
        }


        // For Update or Editing Data 
        // [HttpGet]
        // public async Task <IActionResult> Update(Guid id)
        // {
        //     var updateAnimal = await dbcontext.Animals.FindAsync(id);

        //     return View(updateAnimal);
        // }
        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var animal = await dbcontext.Animals.FindAsync(id);

            if (animal == null)
                return NotFound();

            var viewModel = new UpdateAnimalViewModel
            {
                Id = animal.Id,
                Name = animal.Name,
                Age = animal.Age,
                Species = animal.Species,
                CareTaker = animal.CareTaker,
                OriginatedPlace = animal.OriginatedPlace,
                OriginalOwner = animal.OriginalOwner,
                DateAdded = animal.DateAdded,
                SpeciesList = await dbcontext.AnimalSpecies
                    .OrderBy(s => s.SpeciesName)
                    .Select(s => new SelectListItem
                    {
                        Value = s.SpeciesName,
                        Text = s.SpeciesName
                    })
                    .ToListAsync()
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Update(UpdateAnimalViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload SpeciesList if validation fails
                model.SpeciesList = await dbcontext.AnimalSpecies
                    .OrderBy(s => s.SpeciesName)
                    .Select(s => new SelectListItem
                    {
                        Value = s.SpeciesName,
                        Text = s.SpeciesName
                    })
                    .ToListAsync();

                return View(model);
            }

            var animal = await dbcontext.Animals.FindAsync(model.Id);

            if (animal != null)
            {
                animal.Name = model.Name;
                animal.Age = model.Age;
                animal.Species = model.Species;
                animal.CareTaker = model.CareTaker;
                animal.OriginatedPlace = model.OriginatedPlace;
                animal.OriginalOwner = model.OriginalOwner;

                await dbcontext.SaveChangesAsync();
                TempData["SuccessMessage"] = "Updated!";
            }

            return RedirectToAction("Read");
        }


        // For Delete or Deleting Data 
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delAnimal = await dbcontext.Animals.FindAsync(id);

            if (delAnimal is not null)
            {
                dbcontext.Animals.Remove(delAnimal);
                await dbcontext.SaveChangesAsync();
            }

            return RedirectToAction("Read", "Animal");
        }

    }
}
