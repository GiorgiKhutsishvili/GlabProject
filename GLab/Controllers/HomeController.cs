using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLab.Models;

namespace GLab.Controllers
{
    public class HomeController : Controller
    {
        GlbDBDataContext db = new GlbDBDataContext();
        // GET: Home
        public ActionResult Index()
        {
            var result = new ConsumedModels
            {
                UsrPsts = db.UserPosts.Where(x => x.ID == x.ID).ToList()
            };
            return View(result);
           
        }

        public ActionResult InternalPage(int id)
        {
            var result = new ConsumedModels
            {
                SingleUserPost = db.UserPosts.FirstOrDefault(x => x.ID == id),
            };
            return View(result);
        }
    }
}