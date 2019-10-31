using System.Collections.Generic;
using Pluralsight.Models;

namespace Pluralsight.Services
{
    public interface IRestaurantData
    {
         IEnumerable<Restaurant> GettAll();
    }
    
}