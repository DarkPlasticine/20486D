using AnimalsMvc.Models;
using Microsoft.AspNetCore.Mvc;

namespace AnimalsMvc.Controllers
{
    public class AnimalsController : Controller
    {
        private IData _tempData { get; set; }

        public AnimalsController(IData tempData)
        {
            _tempData = tempData;
        }

        public IActionResult Index()
        {
            var animals = _tempData.AnimalsInitializeData();
            var indexViewModel = new IndexViewModel();
            indexViewModel.Animals = animals;
            return View(indexViewModel);
        }

        public IActionResult Details(int? id)
        {
            var model = _tempData.GetAnimalById(id);

            if (model == null)
            {
                return NotFound();
            }

            return View(model);
        }
    }
}
