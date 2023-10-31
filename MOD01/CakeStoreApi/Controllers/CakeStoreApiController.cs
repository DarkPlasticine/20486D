using CakeStoreApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CakeStoreApi.Controllers
{
    public class CakeStoreApiController : Controller
    {
        private IData _data { get; set; }

        public CakeStoreApiController(IData data) 
        {
            _data = data;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/api/CakeStore")]
        public ActionResult<List<CakeStore>> GetAll()
        {
            return _data.CakesInitializeData();
        }

        [HttpGet("/api/CakeStore/{id}", Name ="GetCake")]
        public ActionResult<CakeStore> GetById(int? id)
        {
            var item = _data.GetCakeById(id);

            if (item == null) { return NotFound(); }

            return new ObjectResult(item);
        }
    }
}
