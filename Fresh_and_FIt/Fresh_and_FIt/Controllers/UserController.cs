using Fresh_and_FIt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fresh_and_FIt.Controllers
{
    public class UserController : Controller
    {
        FnF_context db = new FnF_context();

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User model)
        {
            if (ModelState.IsValid)
            {
                var user = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)
                {
                    Session["UserId"] = user.Id;
                    Session["UserName"] = user.Name;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid login attempt. Please check your email and password.");
                }
            }

             return View(model);
        }


        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = db.Users.FirstOrDefault(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "This email is already registered.");
                    return View(model);
                }
                db.Users.Add(model);
                db.SaveChanges();

                // log the user in after registration
                Session["UserId"] = model.Id;
                Session["UserName"] = model.Name;

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }



        public ActionResult Logout()
        {
            Session.Clear(); // Clear all sessions
            return RedirectToAction("Index", "Home");
        }


        // Action to display the shop page with filtered meals
        public ActionResult Shop(string dietType)
        {
            // Define diet types
            string[] dietTypes = { "Keto", "Vegan", "Paleo", "Mediterranean", "Pescatarian", "Low Sodium",
                               "Low Carb", "Vegetarian", "Gluten Free", "Whole30", "Dairy Free", "Low Fat" };

            // List to store selected meals
            var featuredMeals = new List<Meal>();

            // Iterate over each diet type and select 8 random meals
            foreach (var type in dietTypes)
            {
                var mealsForType = db.Meals
                                     .Where(m => m.DietType.Equals(type, StringComparison.OrdinalIgnoreCase))
                                     .ToList();

                featuredMeals.AddRange(mealsForType);
            }

            // If a specific diet type is selected, filter the meals by that diet type
            if (!string.IsNullOrEmpty(dietType))
            {
                featuredMeals = featuredMeals
                                .Where(m => m.DietType.Equals(dietType, StringComparison.OrdinalIgnoreCase))
                                .ToList();
            }

            // Create a view model to hold the data
            var viewModel = new ShopViewModel
            {
                DietTypes = dietTypes,
                Meals = featuredMeals,
                SelectedDietType = dietType
            };

            return View(viewModel);
        }




    }



}