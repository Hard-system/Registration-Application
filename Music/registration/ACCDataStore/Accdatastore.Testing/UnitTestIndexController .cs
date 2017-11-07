using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACCDataStore.Web.Areas.Index.Controllers;
using ACCDataStore.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Accdatastore.Testing
{
    //Tests Written Completed Here!
    [TestClass]
    public class UnitTestIndexController
    {
        [TestMethod]
        public void Index()
        {
            var controller = new IndexController();
            var result = controller.Index() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Aberdeen Primary Schools", result.ViewData["Title"]);
        }

        //[TestMethod]
        //public void About()
        //{
        //   var controller = new IndexController();
        //    var result = controller.About() as ViewResult;
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("About Us", result.ViewData["Title"]);
        //}

        [TestMethod]
        public void ContactTitle()
        {
            var controller = new IndexController();
            var result = controller.Contact() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Contact", result.ViewData["Title"]);
        }
       
        [TestMethod]
        public void ContactMsg()
        {
            var controller = new IndexController();
            var result = controller.Contact() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("This is a test message.", result.ViewData["Message"]);
        }
    }
}
