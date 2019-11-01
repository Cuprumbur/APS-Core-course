using System.ComponentModel.DataAnnotations;
using Pluralsight.Models;

namespace Pluralsight.ViewModels
{
    public class RestaurantEditModel
    {

        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}