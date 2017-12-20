using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLab.Controllers;
using GLab.Models;
namespace GLab.Controllers
{
    public class AccountController : Controller
    {
        GlbDBDataContext db = new GlbDBDataContext();

        //Random 32 Bit Hash String
        string randomSecret = "4afd759a8e1df217901aaeecd1ea9949";

        // GET: Account
        public ActionResult Index()
        {
            return View();
        }

        
        [HttpPost]
        public ActionResult Login(ConsumedModels login)
        {
            UserRegistration user = db.UserRegistrations.FirstOrDefault(x => x.Email == login.UsrEmail && x.Password == MD5Hash(randomSecret + login.UsrPassword));

            if(user == null)
            {
                ViewBag.LoginFailed = "მომხმარებლის სახელი ან პაროლი არასწორია";
                return RedirectToAction("Login", "Account");
            }
            else
            {
                Session["user"] = user;
                //return Json("LoginSucceeded");
                return RedirectToAction("AddPost", "Admin");
            }

            
        }

        public ActionResult LogOut()
        {
            Session.Clear();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Registration()
        {
            if (Session["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //User Registration
        [HttpPost]
        public ActionResult Registration(RegistrationModel user)
        {
            if (db.UserRegistrations.Where(x=> x.Email == user.Email).Count() > 0)
            {
                ViewBag.RegistrationFailed = "ასეთი ელ.ფოსტით მომხმარებელი დარეგისტრირებულია";
                return View();
            }
            else
            {

                UserRegistration u = new UserRegistration();
                u.Name = user.Name.Trim();
                u.Surname = user.Surname.Trim();
                u.Email = user.Email.Trim();
                u.Password = MD5Hash(randomSecret + user.Password.Trim());

                db.UserRegistrations.InsertOnSubmit(u);
                db.SubmitChanges();

                ViewBag.RegistrationSuccess = "თქვენ წარმატებით დარეგისტრირდით, გთხოვთ გაიაროთ ავტორიზაცია";
                return View();
            }
        }

        //Password Hash
        public string MD5Hash(string input)
        {
            byte[] data = System.Security.Cryptography.MD5.Create().ComputeHash(System.Text.Encoding.UTF8.GetBytes(input));
            string md5 = "";
            for (int i = 0; i < data.Length; i++)
            {
                md5 += data[i].ToString("x2");
            }
            return md5;
        }
        //End Password Hash
    }
}