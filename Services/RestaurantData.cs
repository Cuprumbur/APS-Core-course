using System.Linq;
using System.Collections.Generic;
using Pluralsight.Models;
using Microsoft.AspNetCore.Mvc;

namespace Pluralsight.Services
{
    public class InMemoryRestaurantData : IRestaurantData
    {
        private readonly List<Restaurant> _restaurants;

        public InMemoryRestaurantData()
        {
            _restaurants = new List<Restaurant>
            {
                new Restaurant{ Id=1, Name= "Scott's Pizza Place" },
                new Restaurant{ Id=2, Name= "Tersiguels" },
                new Restaurant{ Id=3, Name= "King;s Contivance" },
            };
        }

        public Restaurant Add(Restaurant restaurant)
        {
            var newRestaurant = new Restaurant
            {
                Cuisine = restaurant.Cuisine,
                Name = restaurant.Name
            };
            newRestaurant.Id = _restaurants.Max(x => x.Id) + 1;
            _restaurants.Add(newRestaurant);
            return newRestaurant;
        }

        public Restaurant Get(int id)
        {
            return _restaurants.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Restaurant> GettAll()
        {
            return _restaurants.OrderBy(x => x.Name);
        }
    }
}