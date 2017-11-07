using System.Web.Mvc;
using ACCDataStore.Web.Controllers;


namespace ACCDataStore.Web.Areas.Index.Controllers
{
    public class IndexController : BaseController
    {
        // GET: Index
        public ActionResult Index()
        {
            ViewBag.Title = "Aberdeen Primary Schools";
            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Title = "Contact";
            ViewBag.Message = "This is a test message.";
            return View();
        }
        //[Authorize(Users= "admin@gmail.com")]//<<--uses system.web.mvc and system.web.http
        //public ActionResult About()
        //{
        //    ViewBag.Title = "About Us";
        //    return View();
        //}

        public ActionResult Manage()
        {
            return View();
        }
    }
}