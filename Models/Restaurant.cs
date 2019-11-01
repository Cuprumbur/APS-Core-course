using System.ComponentModel.DataAnnotations;
namespace Pluralsight.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        [Display(Name = "Restaurant name")]
        [Required, MaxLength(80)]
        public string Name { get; set; }
        public CuisineType Cuisine { get; set; }
    }
}