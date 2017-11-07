using ACCDataStore.Entity;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ACCDataStore.Web.Controllers
{
    public class BaseController : Controller
    {
        private static Logger log = LogManager.GetCurrentClassLogger();

        protected JsonResult ThrowJsonError(Exception ex)
        {
            Response.StatusCode = (int)System.Net.HttpStatusCode.BadRequest;
            var sErrorMessage = "Error : " + ex.Message + (ex.InnerException != null ? ", More Detail : " + ex.InnerException.Message : "");
            log.Error(ex, ex.Message);
            return Json(new { Message = sErrorMessage }, JsonRequestBehavior.AllowGet);
        }

        protected User GetLoginedUser()
        {
            return Session["SessionLoginedUser"] as User;
        }
    }
}