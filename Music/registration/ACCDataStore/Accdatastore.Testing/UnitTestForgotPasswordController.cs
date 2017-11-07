using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACCDataStore.Web.Areas.ForgotPassword.Controllers;
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
    public class UnitTestForgotPasswordController
    {
        [TestMethod]
        public void CheckEmail()
        {
            ForgotPasswordController controller = new ForgotPasswordController();
            ViewResult result = controller.CheckYourEmail() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.IsNotNull(result);
        }

        [TestMethod]
        public void PasswordSuccess()
        {
           var controller = new ForgotPasswordController();
            var result = controller.PasswordSuccess() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Confirm Email", result.ViewData["Title"]);
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
