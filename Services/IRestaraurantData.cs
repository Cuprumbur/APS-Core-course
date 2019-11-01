using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Pluralsight.Models;

namespace Pluralsight.Services
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GettAll();
        Restaurant Get(int id);
        Restaurant Add(Restaurant newRestaurant);
    }

}