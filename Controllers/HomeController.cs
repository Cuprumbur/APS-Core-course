using Microsoft.AspNetCore.Mvc;
using Pluralsight.Models;
using Pluralsight.Services;

namespace Pluralsight.Controllers {
    public class HomeController : Controller {
        private readonly IRestaurantData _restaurantData;
        public HomeController (IRestaurantData restaurantData) {
            this._restaurantData = restaurantData;

        }
        public IActionResult Index () {
            var model = _restaurantData.GettAll();
            return View (model);
        }

    }
}