using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using ACCDataStore.Web.Areas.Login.Controllers;
using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Core.Helper;
using System;
using System.Linq;
using System.Collections.Generic;

namespace Accdatastore.Testing
{
    [TestClass]
    public class UnitTestLoginController
    {
        [TestMethod]
        public void ConfirmEmail()
        {
            var controller = new LoginController();
            var result = controller.ConfirmEmail() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Confirm Email", result.ViewData["Title"]);
        }

        [TestMethod]
        public void Error()
        {
            var controller = new LoginController();
            var result = controller.Error() as ViewResult;
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Error.", result.ViewData["Title"]);
        }

     


        //[TestMethod]
        //public void Index()
        //{
        //    var controller = new LoginController();
        //    var result = controller.Index() as ViewResult;
        //    Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("Login Page", result.ViewData["Title"]);
        //}
        //private readonly IGenericRepository rpGeneric;
        //[TestMethod]
        //public void Validate()
        //{
        //    //user.ID = 6;
        //    var user = new User();
        //    user.Email = "admin@gmail.com";
        //    user.Password = "password12";
        //    user.Fullname = "Pesho";
        //    user.IsAdministrator = true;
        //    user.Enable = true;
        //    user.Gender = "Male";
        //    user.Password1 = "Admin12345";
        //    user.Organization = "aa";
        //    user.Occupation = "aa";
        //    user.Token = "aa";
        //    user.TokenExpired = false;
        //    user.TokenStart = "aa";
        //    user.EmailConfirmed = true;
        //    var userEmail = user.Email;

        //    var lst = new List<User>()
        //       {
        //            new User() {  ID = 6,
        //    //user1.Email = "admin@gmail.com";
        //    //Password = "password",
        //    Fullname = "Pesho",
        //    IsAdministrator = true,
        //    Enable = true,
        //    Gender = "Male",
        //    Password1 = "Adminw12345",
        //    Organization = "aa",
        //    Occupation = "aa",
        //    Token = "aa",
        //    TokenExpired = false,
        //    TokenStart = "aa",
        //    EmailConfirmed = true
        //},


        //    new User() {  ID = 6,
        //    //user1.Email = "admin@gmail.com";
        //    //Password = "password",
        //    Fullname = "Pesho",
        //    IsAdministrator = true,
        //    Enable = true,
        //    Gender = "Male",
        //    Password1 = "Adminw12345",
        //    Organization = "aa",
        //    Occupation = "aa",
        //    Token = "aa",
        //    TokenExpired = false,
        //    TokenStart = "aa",
        //    EmailConfirmed = true } };




        //    // var userEmail2 = user1.Email;

        //    var callMethod = new LoginController();

        //    //var currentUser = this.rpGeneric.Find<User>(" from User WHERE Email=:email ", new string[] { "email" }, new object[] { userEmail }).FirstOrDefault();

        //    //var userPassword = user.Password;
        //    //var encryptpassword = EncryptHelper.EncryptString(userPassword, "key");
        //    //var currentUserPassword = currentUser.Password;


        //    // var result = callMethod.ValidateTesting(user); /*as ViewResult;*/
        //    //Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual("This is a test message.", result.ViewData["Message"]);


        //    Assert.AreEqual(lst.Count(), callMethod.ValidateTesting().Count(),3);
        //}

    }
}
