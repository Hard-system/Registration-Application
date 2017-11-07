using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using NLog;
using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using ACCDataStore.Core.Helper;
using System.Text;
using ACCDataStore.Web.Areas.Authorisation.Controllers;
using Microsoft.AspNet.Identity.Owin;
using ACCDataStore.Web.Helpers.Attribute;
using System.Collections.Generic;

namespace ACCDataStore.Web.Areas.Login.Controllers
{
    public class LoginController : BaseController
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;


        public LoginController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }


        public LoginController()
        {

        }

        // GET: Login/Login
        public ActionResult Index()
        {
            //ViewBag.Title = "Login Page";
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Index", new { area = "Index" });
            }
            else
            {

                return View();
            }
        }
        //Confirm EMail page
        public ActionResult ConfirmEmail()
        {
            ViewBag.Title = "Confirm Email";

            return View();
        }
        //Error page
        public ActionResult Error()
        {
            ViewBag.Title = "Error.";
            return View();
        }
        //Check if token not expired then user will be able to login, 
        //if expired then we token must be generated!
        [HttpGet]
        [Route("Login/Login/Check/{token}")]
        [Transactional]
        public ActionResult Check(string token, User currentuser)
        {
            User userAttr = new User();
            var Token = userAttr.Token;
            RegistrationController myinstance = new RegistrationController();
            currentuser = this.rpGeneric.Find<User>(" from User WHERE Token=:token  ", new string[] { "token" }, new object[] { token }).FirstOrDefault();


            byte[] dbTokenstart = Convert.FromBase64String(currentuser.TokenStart);
            byte[] currentTimeToken = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            bool confirm = true;
            //convert the tokenStarts to DateTime
            DateTime dbToken = DateTime.FromBinary(BitConverter.ToInt64(dbTokenstart, 0));

            if (token == currentuser.Token)
            {
                if (dbToken > DateTime.UtcNow.AddHours(-1))
                {
                    currentuser.TokenExpired = false;
                    currentuser.EmailConfirmed = confirm;
                    this.rpGeneric.SaveOrUpdate<User>(currentuser);
                    return RedirectToAction("ConfirmEmail", "Login", new { area = "Login" });
                }

            }
            currentuser.TokenExpired = true;
            this.rpGeneric.Delete<User>(currentuser);

            return RedirectToAction("Error", "Login", new { area = "Login" });

        }


       

        //Checking password and email match
        [HttpPost]
        public ActionResult Validate(User eUser)
        {
            try
            {
                //Pull email and password from login page
                var Email = eUser.Email;
                var Password = eUser.Password;

                //Pull first email and password from database
                var currentUser = this.rpGeneric.Find<User>(" from User WHERE Email=:email ", new string[] { "email" }, new object[] { Email }).FirstOrDefault();

                //encrypting the login user password 
                //the encrypter and decrypter must have same key which is 'key' below
                var encryptpassword = EncryptHelper.EncryptString(eUser.Password, "key");
                //Comparing user password in login page and current password in db
                if (currentUser != null && encryptpassword.Equals(currentUser.Password, StringComparison.Ordinal) && currentUser.EmailConfirmed == true)
                {
                    System.Web.Security.FormsAuthentication.SetAuthCookie(eUser.Email, false);
                    return RedirectToAction("Index", "Index", new { area = "Index" });
                }
                else
                {
                    TempData["Message"] = "Login failed. Email or password supplied not found.";
                    return View("Index");
                }
            }

            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        

        //Logout method
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}
