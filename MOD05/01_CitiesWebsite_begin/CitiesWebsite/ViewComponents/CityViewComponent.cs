using CitiesWebsite.Models;
using CitiesWebsite.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CitiesWebsite.ViewComponents
{
    public class CityViewComponent: ViewComponent
    {
        private ICityProvider _cities;

        public CityViewComponent(ICityProvider cities) {
            _cities = cities;
        }

        public async Task<IViewComponentResult> InvokeAsync(string cityName)
        {
            ViewBag.CurrentCity = await GetCityAsync(cityName);
            return View("SelectCity");
        }

        private Task<City> GetCityAsync(string cityName)
        {
            return Task.FromResult<City>(_cities[cityName]);
        }
    }
}
