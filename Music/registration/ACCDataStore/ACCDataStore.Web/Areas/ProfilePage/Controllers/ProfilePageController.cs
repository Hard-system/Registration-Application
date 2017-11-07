using System;
using System.Web.Mvc;
using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using ACCDataStore.Web.Helpers.Attribute;
using NLog;
using ACCDataStore.Core.Helper;
using System.Linq;

namespace ACCDataStore.Web.Areas.ProfilePage.Controllers
{

   
    public class ProfilePageController : BaseController
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public ProfilePageController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }

        public ProfilePageController()
        {

        }

        // GET: ProfilePage/ProfilePage
        [Authorize]
        public ActionResult Index()
        {
            ViewBag.Title = "My Profile";
            return View("Index");
        }

        //change password in profile page
        public ActionResult ChangePass()
        {
           
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index", new { area = "Index" });
            }
        }
        //PasswordChange page!
        public ActionResult PasswordChanged()
        {
            if (Request.IsAuthenticated)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Index", new { area = "Index" });
            }
        }

        //Take the details by ID
        [HttpGet]
        [Route("ProfilePage/ProfilePage/GetByID/{nID:int}")]
        public JsonResult GetByID(int nID)
        {
            try
            {
                object oResult = null;
                var eUser = this.rpGeneric.FindById<User>(nID);
                if (Request.IsAuthenticated)
                {

                    oResult = new
                    {
                        User = eUser.GetJson()
                    };
                }
                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }
        //Checks if email exist in db and currentlly logged in with, then user is able to change password and redirect to page.
        [HttpPost]
        [Route("ProfilePage/ProfilePage/Save")]
        [Transactional]
        public ActionResult Save(User user)
        {

            //Pull email and password from profile page
            var Email = user.Email;
            var Password1 = user.Password1;
            var Password = user.Password;

            User useremail = this.rpGeneric.Find<User>(" from User WHERE Email like :email  ", new string[] { "email" }, new object[] { user.Email }).FirstOrDefault();
           
             try
            {
                if (useremail.Email.Equals(user.Email))
                {
                   
                    useremail.Password = EncryptHelper.EncryptString(Password, "key");
                    useremail.Password1 = EncryptHelper.EncryptString(Password1, "key123");
                    this.rpGeneric.SaveOrUpdate<User>(useremail);
                }
                return RedirectToAction("PasswordChanged", "ProfilePage", new { area = "ProfilePage" });
               

            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }

        }




    }
}

