using ACCDataStore.Entity;
using ACCDataStore.Entity.RenderObject.Charts.ColumnCharts;
using ACCDataStore.Entity.RenderObject.Charts.SplineCharts;
using ACCDataStore.Entity.SchoolProfiles.Census.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Areas.SchoolProfiles.ViewModels;
using ACCDataStore.Web.Controllers;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace ACCDataStore.Web.Areas.Registration.Controllers
{
    public class RegisterController : BaseController
    {

        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public RegisterController (IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }

        // GET: Registration/Regsiter
        public ActionResult Index1()
        {
            return View();
        }
    }
}