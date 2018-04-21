using System;
using System.Collections.Generic;
using System.Linq;
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

                AdoTickrModel db = new AdoTickrModel();
                
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Password = model.Password;
               

                db.Users.Add(user);

                db.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            


            return RedirectToAction("Index", "Home");
            
            
        }

        public ActionResult GetUser(User model)
        {
            AdoTickrModel db = new AdoTickrModel();
            //List<User> users = new List<User>();

            /*var user = from i in db.Users
                       where i.Email == model.Email && i.Password == model.Password
                       select i;*/

            //var users = db.Users.Where(i => i.Email == model.Email && i.Password == model.Password).FirstOrDefault();
            var users = db.Users.Select(u => new { u.Email, u.Password });

            

            /*foreach(var user in users)
            {
                if (user.Email == model.Email && user.Password == model.Password)
                {
                    return RedirectToAction("Index", "Home");
                }

            }*/

       

            
        }
    }
}