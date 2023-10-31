using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using WorldJourney.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using WorldJourney.Filters;

namespace WorldJourney.Controllers
{
    public class CityController : Controller
    {
        private IData _data;
        private IHostingEnvironment _environment;

        public CityController(IData data, IHostingEnvironment environment)
        {
            _data = data; 
            _environment = environment;
            _data.CityInitializeData();
        }

        [ServiceFilter(typeof(LogActionFilterAttribute))]
        [Route("WorldJourney")]
        public IActionResult Index()
        {
            ViewData["Page"] = "Search City";
            return View();
        }

        [Route("CityDetails/{id?}")]
        public IActionResult Details(int? id)
        {
            ViewData["Page"] = "Selected City";

            City city = _data.GetCityById(id);

            if (city == null)
            {
                return NotFound();
            }

            ViewBag.Title = city.CityName;

            return View(city);
        }

        public IActionResult GetImage(int? cityId)
        {
            ViewData["Message"] = "Display Image";

            City requestedCity = _data.GetCityById(cityId);

            if (requestedCity != null)
            {
                var webRootpath = _environment.WebRootPath;
                var folderPath = @"\images\";

                var fullPath = $"{webRootpath}{folderPath}{requestedCity.ImageName}";


                var fileOnDisk = new FileStream(fullPath, FileMode.Open);

                byte[] fileByte;

                using (var br =  new BinaryReader(fileOnDisk))
                {
                    fileByte = br.ReadBytes((int)fileOnDisk.Length);
                }

                return File(fileByte, requestedCity.ImageMimeType);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
