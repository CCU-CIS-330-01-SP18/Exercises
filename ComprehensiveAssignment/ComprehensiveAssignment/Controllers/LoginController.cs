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
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CreateUser(User model)
        {
            try
            {
                var user = new User();
                var hashedPassword = HashPassword(model.Password);

                AdoTickrModel db = new AdoTickrModel();
                
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                //user.Password = model.Password;
                user.Password = Encoding.UTF8.GetString(hashedPassword);
                

                db.Users.Add(user);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            


            return RedirectToAction("Index", "Home");
            
            
        }

        public static byte[] HashPassword(string valuedInfo)
        {
            string password = valuedInfo;
            byte[] data = Encoding.UTF8.GetBytes(password);
            byte[] hash = SHA256.Create().ComputeHash(data);

            return hash;
        }

        public ActionResult GetUser(User model)
        {
            ActionResult action = null;
            AdoTickrModel db = new AdoTickrModel();

            var hashedPassword = HashPassword(model.Password);
            //List<User> users = new List<User>();

            var retrievedPassword = Encoding.UTF8.GetString(hashedPassword);
            /*var user = from i in db.Users
                       where i.Email == model.Email && i.Password == model.Password
                       select i;*/

            var user = db.Users.Where(i => i.Email == model.Email && i.Password == retrievedPassword).FirstOrDefault();
            //var users = db.Users.Select(u => new { u.Email, u.Password });




            if (model.Email == user.Email && user.Password == retrievedPassword)
            {
                action = RedirectToAction("Index", "Login");
            }

            return action;
        }
    }
}