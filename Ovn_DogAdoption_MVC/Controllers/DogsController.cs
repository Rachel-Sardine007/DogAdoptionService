using Microsoft.AspNetCore.Mvc;
using Ovn_DogAdoption_MVC.Models;

namespace Ovn_DogAdoption_MVC.Controllers
{
    public class DogsController : Controller
    {
        // Data on dogs
        private static List<DogModel> dogs = new List<DogModel>
        {
            new DogModel { Id = 1, Name = "Zelda", Cuteness = 7, Image = "Zelda.png",
                Temperament = 4, IsAdopted = false },
            new DogModel{ Id = 2, Name = "Marwin", Cuteness = 10, Image = "Marwin.png",
                Temperament = 8, IsAdopted = false},
            new DogModel { Id = 3, Name = "Lolly", Cuteness = 5, Image = "Lolly.png",
                Temperament = 9, IsAdopted = false},
            new DogModel{ Id = 4, Name = "Sigrid", Cuteness = 7, Image = "Sigrid.png",
                Temperament = 8, IsAdopted = false},
            new DogModel{ Id = 5, Name = "Alfred", Cuteness = 5, Image = "Alfred.png",
                Temperament = 6, IsAdopted = false}
        };

        public IActionResult Index()
        {
            var sortedDogs = dogs.OrderBy(d => d.Name).ToList();
            return View(sortedDogs); // return object sortedDogs
        }

        public IActionResult Details(int id)
        {
            var selectedDog = dogs.FirstOrDefault(d => d.Id == id);
            if (selectedDog == null)
            {
                return NotFound();
            }

            return View(selectedDog);
        }

        public IActionResult Adopt(int id)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null )
            {
                return NotFound();
            }

            if (dog.IsAdopted)
            {
                return BadRequest("Dog already adopted");
            }

            return View(dog);
        }

        [HttpPost]
        public IActionResult Submitted(int id, string applicantName, string email, string message)
        {
            var dog = dogs.FirstOrDefault(d => d.Id == id);
            if (dog == null)
            {
                return NotFound();
            }

            // real app --> save request to DB --> send email --> review manually
            // if succeeded --> IsAdopted = true

            ViewBag.DogName = dog.Name;
            return View("Submitted");
        }
    }
}
