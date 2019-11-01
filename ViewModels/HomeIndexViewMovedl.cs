using System.Collections.Generic;
using Pluralsight.Models;

namespace Pluralsight.ViewModels
{
    public  class HomeIndexViewModel
    {
        public IEnumerable<Restaurant> Restaurants { get; set; }
        public string CurrentMessage { get; set; }
    }
}