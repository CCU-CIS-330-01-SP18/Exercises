using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ComprehensiveAssignment.Models;

namespace ComprehensiveAssignment.Controllers
{
    /// <summary>
    /// Controller that handles the login capabilities.
    /// </summary>
    public class LoginController : Controller
    {
        /// <summary>
        /// Displays the login page that is linked to the Login/index.cshtml View.
        /// </summary>
        /// <returns>The Login/index.cshtml View</returns>
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Method responsible for creating a user.
        /// </summary>
        /// <param name="model">The passed in user from the form in index.cshtml.</param>
        /// <returns>If model state is valid, logs them into the home page. If false,
        /// it directs the user to correct their validation.</returns>
        [HttpPost]
        public ActionResult CreateUser(User model)
        {
            // If there is validation errors, reload the login view.
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }

            var user = new User();

            // Value of hashing the passed in password to the controller.
            var hashedPassword = HashPassword(model.Password);

            AdoTickrModel db = new AdoTickrModel();

            user.FirstName = model.FirstName;
            user.LastName = model.LastName;
            user.Email = model.Email;
            
            // Turns the passed in byte[] to a string format.
            user.Password = Encoding.UTF8.GetString(hashedPassword);

            db.Users.Add(user);

            db.SaveChanges();

            // If validation was correct let them access the home page.
            return RedirectToAction("Index", "Home");
        }

        /// <summary>
        /// Method that turns a password into a hashed value.
        /// </summary>
        /// <param name="valuedInfo">The password passed in from the model.</param>
        /// <returns>The hashed value in the form of a byte array.</returns>
        public static byte[] HashPassword(string valuedInfo)
        {
            string password = valuedInfo;
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }

        /// <summary>
        /// Method responsible for retrieving the user from the database.
        /// </summary>
        /// <param name="model">User model that is passed in from the form.</param>
        /// <returns>Returns an ActionResult depending on whether a correct login was found.</returns>
        
        public ActionResult GetUser(User model)
        {
            // If a user was not found, do not let them login.
            /*if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Login");
            }*/

            ActionResult action = null;
            AdoTickrModel db = new AdoTickrModel();

            // Hash the password inputted.
            var hashedPassword = HashPassword(model.Password);

            // Turn password into a string to match type that password is stored in the database.
            var retrievedPassword = Encoding.UTF8.GetString(hashedPassword);

            // Find the user from the database where their email and password matched.
            var user = db.Users.Where(i => i.Email == model.Email && i.Password == retrievedPassword).FirstOrDefault();

            // If the credentials match whats in the database, log them in.
            if (model.Email == user.Email && user.Password == retrievedPassword)
            {
                action = RedirectToAction("Index", "Home");
            }

            return action;
        }
    }
}