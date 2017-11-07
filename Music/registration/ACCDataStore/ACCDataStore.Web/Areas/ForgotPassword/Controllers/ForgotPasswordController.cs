using ACCDataStore.Core.Helper;
using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using ACCDataStore.Web.Helpers.Attribute;
using NLog;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.ForgotPassword.Controllers
{
    public class ForgotPasswordController : BaseController
    {
        // GET: ForgotPassword/ForgotPassword
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public ForgotPasswordController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }
        public ForgotPasswordController()
        {

        }

        //forgot password page
        public ActionResult Index()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction("Index", "Index", new { area = "Index" });
            }
            else
            {
                return View();
            }
        }


        public ActionResult CheckYourEmail()
        {
            return View();
        }

        //Error Page
        public ActionResult Error()
        {
            return View();
        }


        public ActionResult PasswordSuccess()
        {
            ViewBag.Title = "Password Changed Successfully";
            return View();
        }

        //Redirect to password success method when the user save the new password
        [HttpGet]
        [Route("ForgotPassword/ForgotPassword/GetAll2")]
        public JsonResult GetAll2()
        {
            try
            {
                object oResult = null;
                oResult = new
                {
                    rerouteUser = RedirectToAction("PasswordSuccess", "ForgotPassword", new { area = "ForgotPassword" })
                };
                return Json(oResult, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        //Method used to Redirect the user to checkyouremail page
        [HttpGet]
        [Route("ForgotPassword/ForgotPassword/GetAll")]
        public JsonResult GetAll()
        {
            try
            {
                object oResult = null;
                oResult = new
                {
                    rerouteUser = RedirectToAction("CheckYourEmail", "ForgotPassword", new { area = "ForgotPassword" })
                };
                return Json(oResult, JsonRequestBehavior.AllowGet);
            }

            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        //Generate token
        public void Generate(ForgotPassword1 user)
        {
            byte[] TokenStart = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(TokenStart.Concat(key).ToArray());
            user.Token = token.Replace("+", "").Replace("/", "");
            user.TokenStart = Convert.ToBase64String(TokenStart);
        }

        //Execute method that sends email
        [HttpGet]
        [Transactional]
        public async Task Execute(User userEmail)
        {

            var email = userEmail.Email;
            var currentuseremail = this.rpGeneric.Find<User>(" from User WHERE Email=:email  ", new string[] { "email" }, new object[] { email }).FirstOrDefault();

            ForgotPassword1 emailInDB = new ForgotPassword1();

            var forgotpasswordemail = emailInDB.Email;

            if (email.Equals(currentuseremail.Email, StringComparison.Ordinal))
            {
                forgotpasswordemail = currentuseremail.Email;
                emailInDB.Email = forgotpasswordemail;

                // generate token before sending the email
                Generate(emailInDB);
                this.rpGeneric.SaveOrUpdate<ForgotPassword1>(emailInDB);

                // send an email with the generated token
                string apiKey = "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";
                var client = new SendGridClient(apiKey);
                var from = new EmailAddress("test@example.com", "Forgot password");
                var subject = "Account Confirmation";
                var to = new EmailAddress(forgotpasswordemail, "Forgot password");
                var tokenholder = emailInDB.Token;
                var urlholder = "http://localhost:13456/ForgotPassword/ForgotPassword/Check/";

                var htmlContent = $"Please reset your password by clicking this link: <a href=\'{urlholder + tokenholder}\'>link</a>";

                var plainTextContent = "!";
                var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

                var response = await client.SendEmailAsync(msg);
            }
            else
            {
                TempData["Message"] = "Your email entered doesn't exist you bastard :-)))";
            }
        }


        [HttpPost]
        [Route("ForgotPassword/ForgotPassword/SendEmail")]
        [Transactional]
        public async Task<ActionResult> SendEmail(User eUser)
        {
            await Execute(eUser);

            try
            {
                return RedirectToAction("CheckYourEmail", "ForgotPassword", new { area = "ForgotPassword" });
            }

            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }

        }

        public ActionResult ChangePassword()
        {
            return View();
        }


        //Method Check: checks email and redirect to ChangePassword Method
        [HttpGet]
        [Route("ForgotPassword/ForgotPassword/Check/{token}")]
        [Transactional]
        public ActionResult Check(string token, ForgotPassword1 currentuser)
        {

            var email = currentuser.Email;
            currentuser = this.rpGeneric.Find<ForgotPassword1>(" from ForgotPassword1 WHERE Token=:token  ", new string[] { "token" }, new object[] { token }).FirstOrDefault();
            var forgotpassworduseremail = this.rpGeneric.Find<ForgotPassword1>(" from ForgotPassword1 WHERE Email=:email  ", new string[] { "email" }, new object[] { currentuser.Email }).FirstOrDefault();
            var useremail = this.rpGeneric.Find<User>(" from User WHERE Email=:email  ", new string[] { "email" }, new object[] { forgotpassworduseremail.Email }).FirstOrDefault();


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
                    currentuser.PasswordChanged = confirm;
                    this.rpGeneric.SaveOrUpdate<ForgotPassword1>(currentuser);
                    return RedirectToAction("ChangePassword", "ForgotPassword", new { area = "ForgotPassword" });
                }

            }
            currentuser.TokenExpired = true;
            this.rpGeneric.Delete<ForgotPassword1>(currentuser);

            return RedirectToAction("Error", "ForgotPassword", new { area = "ForgotPassword" });

        }


        [HttpPost]
        [Route("ForgotPassword/ForgotPassword/Save")]
        [Transactional]
        public ActionResult Save(User user)
        {

            //Pull email and password from ChangePassword page
            var Email = user.Email;
            var Password1 = user.Password1;
            var Password = user.Password;

            User useremail = this.rpGeneric.Find<User>(" from User WHERE Email like :email  ", new string[] { "email" }, new object[] { user.Email }).FirstOrDefault();
            var forgotpassworduseremail = this.rpGeneric.Find<ForgotPassword1>(" from ForgotPassword1 WHERE Email like :email  ", new string[] { "email" }, new object[] { user.Email }).FirstOrDefault();

            try
            {
                if (useremail.Email.Equals(forgotpassworduseremail.Email))
                {
                    useremail.Password = EncryptHelper.EncryptString(Password, "key");
                    useremail.Password1 = EncryptHelper.EncryptString(Password1, "key123");
                    this.rpGeneric.SaveOrUpdate<User>(useremail);
                    this.rpGeneric.Delete<ForgotPassword1>(forgotpassworduseremail);
                }

                return RedirectToAction("PasswordSuccess", "ForgotPassword", new { area = "ForgotPassword" });

            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }

        }

    }
}