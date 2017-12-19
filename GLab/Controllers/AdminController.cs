using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GLab.Models;
using System.IO;

namespace GLab.Controllers
{
    public class AdminController : Controller
    {
        GlbDBDataContext db = new GlbDBDataContext();

        public string Random32()
        {
            return Guid.NewGuid().ToString("N");
        }

        // GET: Admin
        public ActionResult AddPost()
        {

            if(Session["user"] == null)
            {
                return RedirectToAction("Index", "Home");
            }

            //All Posts From Db to List in View
            var result = new ConsumedModels
            {
                UsrPsts = db.UserPosts.Where(x => x.ID == x.ID).ToList()
            };
            return View(result);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddPost(HttpPostedFileBase file, string NewsTitle, string AuthorName, string AuthorSurname, string NewsText)
        {
            var path = ""; //for path to save

            if(file != null) //check file is null or not
            {
                if(file.ContentLength > 0) //check length of bytes are greater then zero or not
                {
                    //სურათის სახელის წამოღება
                    var pictureName = Path.GetFileName(file.FileName);
                    pictureName = Random32();

                    //სურათის სახელის წამოღება extension-ისთვის
                    string fileNameExt = Path.GetFileName(file.FileName);
                    string pictureExtension = Path.GetExtension(fileNameExt);

                    //ფაილების შემოწმება სურათი არის თუ არა
                    if(Path.GetExtension(file.FileName).ToLower() == ".jpg" || Path.GetExtension(file.FileName).ToLower() == ".png" || Path.GetExtension(file.FileName).ToLower() == ".gif" || Path.GetExtension(file.FileName).ToLower() == ".jpeg")
                    {
                        path = Path.Combine(Server.MapPath("~/Content/Images"), pictureName + pictureExtension);
                        file.SaveAs(path);
                    }

                    UserRegistration user = (UserRegistration)Session["user"];
                    var thisLoggedUser = db.UserRegistrations.FirstOrDefault(x => x.ID == user.ID);

                    UserPost UserPst = new UserPost();
                    UserPst.UserID = thisLoggedUser.ID;
                    UserPst.NewsTitle = NewsTitle;
                    UserPst.AuthorName = AuthorName;
                    UserPst.AuthorSurName = AuthorSurname;
                    UserPst.NewsText = NewsText;
                    UserPst.PicturePath = path;
                    UserPst.PictureName = pictureName;
                    UserPst.PictureExtension = pictureExtension;
                    UserPst.CreateDate = DateTime.Now;

                    db.UserPosts.InsertOnSubmit(UserPst);
                    db.SubmitChanges();

                }
            }

            return RedirectToAction("AddPost", "Admin");
        }


        public JsonResult GetCurrentPost(int ID)
        {
            try
            {
                var CurrentPost = db.UserPosts.FirstOrDefault(x => x.ID == ID);

                var result = new
                {
                    Result = "success",
                    NewsTitle = CurrentPost.NewsTitle,
                    AuthorName = CurrentPost.AuthorName,
                    AuthorSurname = CurrentPost.AuthorSurName,
                    NewsText = CurrentPost.NewsText

                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new
                {
                    Result = "error"
                };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [ValidateInput(false)]
        [HttpPost]
        public JsonResult EditPost(HttpPostedFileBase file, int ID, string NewsTitle, string AuthorName, string AuthorSurname, string NewsText)
        {
            try
            {

                var updateUserpost = db.UserPosts.FirstOrDefault(x => x.ID == ID);
                updateUserpost.NewsTitle = NewsTitle;
                updateUserpost.AuthorName = AuthorName;
                updateUserpost.AuthorSurName = AuthorSurname;
                updateUserpost.NewsText = NewsText;
                updateUserpost.CreateDate = DateTime.Now;
                db.SubmitChanges();

                var result = new { Result = "success" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            catch
            {
                var result = new { Result = "error" };
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteUserPost(int Id)
        {
            db.UserPosts.DeleteOnSubmit(db.UserPosts.Where(x => x.ID == Id).FirstOrDefault());
            db.SubmitChanges();

            return Json("DeleteSucceeded", JsonRequestBehavior.AllowGet);
        }
    }
}