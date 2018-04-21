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
    }
}