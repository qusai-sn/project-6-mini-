using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fresh_and_FIt.Models
{

    public class HomeViewModel
    {
        public List<Meal> FeaturedMeals { get; set; }
        public List<Meal> LatestMeals { get; set; }
        public List<Meal> TopRatedMeals { get; set; }
        public List<Meal> ReviewMeals { get; set; }
        public string[] DietTypes { get; set; } // Add this line
        public string SelectedDietType { get; set; }
    }
    public class ShopViewModel
    {
        public string[] DietTypes { get; set; }
        public List<Meal> Meals { get; set; }
        public string SelectedDietType { get; set; }
    }


}