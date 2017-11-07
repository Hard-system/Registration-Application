using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACCDataStore.Web.Areas.ProfilePage.Controllers;
using ACCDataStore.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web;
using Moq;
using System.Security.Principal;
using ACCDataStore.Entity;
using ACCDataStore.Core.Helper;

namespace Accdatastore.Testing
{
    //Tests Written Completed Here!
    [TestClass]
    public class UnitTestProfilePageController
    {
        [TestMethod]
        public void Index()
        {
            var controller = new ProfilePageController();
            var result = controller.Index() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("My Profile", result.ViewData["Title"]);
        }

        [TestMethod]
        public void ChangePass()
        {
            User user = new User();
            user.Email = "admin@gmail.com";
            var myuser = user.Email;
            user.Password = "Admin12345";
            var encryptpassword = EncryptHelper.EncryptString(user.Password, "key");
            
            var myuserpassword = encryptpassword;
            var callmethod = new ProfilePageController();
            User newuser = new User();
            user = newuser;

            var controller = new ProfilePageController();
            var result = controller.ChangePass() as ViewResult;
           // Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Error.", result.ViewData["Title"]);


            Assert.AreEqual(user,result);

            //var identity = new GenericIdentity("tugberk");
            //var controller = new ProfilePageController();

            //var controllerContext = new Mock<ControllerContext>();
            //var principal = new Mock<IPrincipal>();
            //principal.Setup(p => p.IsInRole("Administrator")).Returns(true);
            //principal.SetupGet(x => x.Identity.Name).Returns("tugberk");
            //controllerContext.SetupGet(x => x.HttpContext.User).Returns(principal.Object);
            //controller.ControllerContext = controllerContext.Object;

            //Assert.AreEqual(controller.ChangePass(), identity.Name);

            //var username = "user";
            //var httpContext = Moq.MockRepository.(HttpContextBase);
            //var request = MockRepository.GenerateMock<HttpRequestBase>();
            //var identity = MockRepository.GenerateMock<IIdentity>();
            //var principal = MockRepository.GenerateMock<IPrincipal>();

            //httpContext.Expect(c => c.Request).Return(request).Repeat.AtLeastOnce();
            //request.Expect(r => r.IsAuthenticated).Return(true).Repeat.AtLeastOnce();
            //httpContext.Expect(c => c.User).Return(principal).Repeat.AtLeastOnce();
            //principal.Expect(p => p.Identity).Return(identity).Repeat.AtLeastOnce();
            //identity.Expect(i => i.Name).Return(username).Repeat.AtLeastOnce();



            //var controller = new ProfilePageController();
            //var result = controller.ChangePass() as ViewResult;
            //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("My Profile", result.ViewData["Title"]);


        }

    }
}
