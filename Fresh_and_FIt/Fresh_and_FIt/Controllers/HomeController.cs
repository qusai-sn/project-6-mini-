using Fresh_and_FIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fresh_and_FIt.Controllers
{
    public class HomeController : Controller
    {
        public FnF_context db = new FnF_context();
        public ActionResult Index()
        {
            // Define diet types
            string[] dietTypes = { "Keto", "Vegan", "Paleo", "Mediterranean", "Pescatarian", "Low Sodium",
                           "Low Carb", "Vegetarian", "Gluten Free", "Whole30", "Dairy Free", "Low Fat" };

            // List to store selected meals
            var featuredMeals = new List<Meal>();

            // Iterate over each diet type and select 4 random meals
            foreach (var dietType in dietTypes)
            {
                var mealsForType = db.Meals
                                     .Where(m => m.DietType.Equals(dietType, StringComparison.OrdinalIgnoreCase))
                                     .OrderBy(r => Guid.NewGuid())
                                     .Take(8)
                                     .ToList();

                featuredMeals.AddRange(mealsForType);
            }

            // Shuffle the selected meals (optional, if you want them to be mixed)
            featuredMeals = featuredMeals.OrderBy(r => Guid.NewGuid()).ToList();

            // Get latest, top-rated, and review meals (adjust logic as necessary)
            var latestMeals = db.Meals.OrderByDescending(m => m.Carbs).Take(9).ToList(); // Latest 6 meals
            var topRatedMeals = db.Meals.OrderByDescending(m => m.Protein).Take(9).ToList(); // Example logic for top-rated
            var reviewMeals = db.Meals.OrderBy(m => m.Carbs).Take(9).ToList(); // Example logic for review meals

            // Populate the view model
            var viewModel = new HomeViewModel
            {
                FeaturedMeals = featuredMeals,
                LatestMeals = latestMeals,
                TopRatedMeals = topRatedMeals,
                ReviewMeals = reviewMeals,
                DietTypes = dietTypes // Add this line
            };

            return View(viewModel);
        }
          

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}