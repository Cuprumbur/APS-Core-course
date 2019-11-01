using Microsoft.AspNetCore.Mvc;
using Pluralsight.Models;
using Pluralsight.Services;
using Pluralsight.ViewModels;

namespace Pluralsight.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRestaurantData _restaurantData;
        private readonly IGreeting _greeting;

        public HomeController(IRestaurantData restaurantData, IGreeting greeting)
        {
            _restaurantData = restaurantData;
            _greeting = greeting;
        }
        public IActionResult Index()
        {
            var model = new HomeIndexViewModel
            {
                Restaurants = _restaurantData.GettAll(),
                CurrentMessage = _greeting.GetMessageOfDay()
            };
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _restaurantData.Get(id);
            if (model == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RestaurantEditModel model)
        {
            if (ModelState.IsValid)
            {
                var newRestaurant = new Restaurant
                {
                    Name = model.Name,
                    Cuisine = model.Cuisine
                };

                newRestaurant = _restaurantData.Add(newRestaurant);

                return RedirectToAction(nameof(Details), new { id = newRestaurant.Id });
            }
            else
            {
                return View();
            }

        }

    }
}