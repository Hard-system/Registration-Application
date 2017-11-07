using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACCDataStore.Web.Areas.Authorisation.Controllers;
using ACCDataStore.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using ACCDataStore.Entity;
using NUnit.Framework;


namespace Accdatastore.Testing
{
    [TestClass]
    public class UnitTestAuthorisationController
    {
        //[TestMethod]
        //public void RegIndex()
        //{
        //    RegistrationController controller = new RegistrationController();
        //    ViewResult result = controller.Index() as ViewResult;
        //    //we need to add if statement
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        //}

        [TestMethod]
        public void CheckEmail()
        {
            RegistrationController controller = new RegistrationController();
            ViewResult result = controller.CheckYourEmail() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }




        [TestMethod]
        public void GetAllFromJSON()
        {
            RegistrationController controller = new RegistrationController();

            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(controller.GetAll(), JsonRequestBehavior.AllowGet);
            
        }











        //[TestMethod]
        //public void Generate()
        //{
        //    RegistrationController controller = new RegistrationController();
        //    ViewResult result = controller.CheckYourEmail() as ViewResult;
        //    Assert.IsNotNull(result);
        //}
    }
}
