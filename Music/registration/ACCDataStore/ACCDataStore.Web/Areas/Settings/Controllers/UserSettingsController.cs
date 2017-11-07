using ACCDataStore.Core.Helper;
using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using ACCDataStore.Web.Helpers.Attribute;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.Settings.Controllers
{
    public class UserSettingsController : BaseController
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public UserSettingsController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }


        //public static string role = "admin@gmail.com";
        //public static string r = "admin@gmail.com";
        [Authorize(Users = "admin@gmail.com")]
        public ActionResult Index()
        {
            

            if (Request.IsAuthenticated)
            {
                return View();
            }
			else{
                return RedirectToAction("Index", "Index", new { area = "Index" }); 

			}
        }

        [HttpGet]
        [Route("Settings/UserSettings/GetAll")]
        public JsonResult GetAll()
        {

            try
            {
                object oResult = null;
                var listUser = this.rpGeneric.Find<User>(" from User order by Email ", new string[] { }, new object[] { });
                var listRequest = this.rpGeneric.Find<Request>(" from Request order by ID ", new string[] { }, new object[] { });
                oResult = new
                {

                    ListUser = listUser.Select(x => x.GetJson()),

                    ListRequest = listRequest.Select(x => x.GetJson())
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        //This is added for the Current User

        [HttpGet]
        [Route("Settings/UserSettings/GetCurrentUser")]
        public JsonResult GetCurrentUser()
        {
            try
            {
               
                var identity = (ClaimsIdentity)User.Identity;               
                IEnumerable<Claim> claims = identity.Claims;
                object oResult = null;
                var eUser = this.rpGeneric.Find<User>("from User where Email like :email",
                    new string[] { "email" }, new string[] { User.Identity.Name }).FirstOrDefault();

                oResult = new
                {
                    User = eUser.GetJson()
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
                
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }


        [HttpGet]
        [Route("Settings/UserSettings/GetByID/{nID:int}")]
        public JsonResult GetByID(int nID)
        {
            try
            {
                object oResult = null;
                var eUser = this.rpGeneric.FindById<User>(nID);

                oResult = new
                {
                    User = eUser.GetJson()
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpGet]
        [Route("Settings/UserSettings/GetDefault")]
        public JsonResult GetDefault()
        {
            try
            {
                object oResult = null;    
                var eUser = new User()      
                {
                    Password = "",
                    Fullname = "Fullname",
                    Email = ""
                };

                oResult = new
                {
                    User = eUser.GetJson()
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }
        // method for CRUD
        [HttpPost]
        [Route("Settings/UserSettings/Save")]
        [Transactional]
        public JsonResult Save(User eUser)
        {
            var encryptpassword = EncryptHelper.EncryptString(eUser.Password, "key");
            var encryptpassword1 = EncryptHelper.EncryptString(eUser.Password1, "key");
            try
            {
                eUser.Password = encryptpassword;
                eUser.Password1 = encryptpassword1;
                this.rpGeneric.SaveOrUpdate<User>(eUser);
                return GetAll();
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        //Method for the SAVE button in the edit profile page

        [HttpPost]
        [Route("Settings/UserSettings/Save1")]
        [Transactional]
        public JsonResult Save1(User eUser)
        {
            try
            {
                this.rpGeneric.SaveOrUpdate<User>(eUser);
                return GetAll();
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        [HttpDelete]
        [Route("Settings/UserSettings/Delete/{nID:int}")]
        [Transactional]
        public JsonResult Delete(int nID)
        {
            try
            {
                this.rpGeneric.Delete<User>(this.rpGeneric.FindById<User>(nID));
                return GetAll();
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }
    }
}