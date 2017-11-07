using ACCDataStore.Core.Helper;
using ACCDataStore.Entity;
using ACCDataStore.Repository;
using ACCDataStore.Web.Controllers;
using ACCDataStore.Web.Helpers.Attribute;
using MySql.Data.MySqlClient;
using NLog;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.Authorisation.Controllers
{
    public class RegistrationController : BaseController
    {
        // GET: Authorisation/Registration
        private static Logger log = LogManager.GetCurrentClassLogger();

        private readonly IGenericRepository rpGeneric;
        public RegistrationController(IGenericRepository rpGeneric)
        {
            this.rpGeneric = rpGeneric;
        }
        public RegistrationController()
        {

        }
        //Method to view the index page
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

        //Method used to Redirect the user to checkyouremail page
        [HttpGet]
        [Route("Authorisation/Registration/GetAll")]
        public JsonResult GetAll()
        {
            try
            {
                object oResult = null;
                oResult = new
                {

                    rerouteUser = RedirectToAction("CheckYourEmail", "Registration", new { area = "Authorisation" })

                };

                return Json(oResult, JsonRequestBehavior.AllowGet);

            }

            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }
        //GetByID takes information for particular user
        [HttpGet]
        [Route("Authorisation/Registration/GetByID/{nID:int}")]
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
        [Route("Authorisation/Registration/GetDefault")]
        public JsonResult GetDefault()
        {
            try
            {
                object oResult = null;

                var eUser = new User()

                {

                    Password = "",
                    Fullname = "Fullname",
                    Email = "",
                    Organization = ""
                };

                var eRequest = new Request()

                {
                    Schoolpro = true,
                    Datahub = true,
                    Widerach = true

                };

                oResult = new
                {
                    User = eUser.GetJson(),
                    Request = eRequest.GetJson()
                };

                return Json(oResult, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }
        }

        // Email validation method below
        [HttpPost]
        [Route("Authorisation/Registration/EmailValidate")]
        [Transactional]
        public JsonResult EmailValidate(string Email)
        {
            string message = "text message";
            try
            {
                string cs = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                using (var connection = new MySqlConnection(cs))
                {
                    using (var command = new MySqlCommand("validate_procedure", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("testemail", Email);
                        connection.Open();
                        string userEmail = (string)command.ExecuteScalar();
                        if (!String.IsNullOrEmpty(userEmail))
                        {
                            //System.Web.Security.FormsAuthentication.SetAuthCookie(Email, false);
                            message = "Email already exist. Please try again";
                        }
                        else
                        {
                            message = "Continue to fill the form!";
                        }
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                message = "Login failed.Error - " + ex.Message;
            }
            return Json(message);
        }
        //end of validation

        //Generate Token
        public void Generate(User user)
        {

            byte[] TokenStart = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            byte[] key = Guid.NewGuid().ToByteArray();
            string token = Convert.ToBase64String(TokenStart.Concat(key).ToArray());
            user.Token = token.Replace("+", "").Replace("/", "");
            user.TokenStart = Convert.ToBase64String(TokenStart);
        }


        //Execute method to Send email!
        public async Task Execute(User userEmail)
        {
            // generate token before sending the email
            Generate(userEmail);

            // send an email with the generated token
            string apiKey = "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";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("test@example.com", "Example User");
            var subject = "Account Confirmation";
            var to = new EmailAddress(userEmail.Email, "Example User");
            var tokenholder = userEmail.Token;
            var urlholder = "http://localhost:13456/Login/Login/Check/";

            var htmlContent = $"Please confirm your account by clicking this link: <a href=\'{urlholder + tokenholder}\'>link</a>";
            var plainTextContent = "!";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);
            var response = await client.SendEmailAsync(msg);

        }

        //Method for saving register inputs in the DB
        [HttpPost]
        [Route("Authorisation/Registration/Save")]
        [Transactional]
        public async Task<JsonResult> Save(User eUser, Request eRequest)
        {
            await Execute(eUser);

            try
            {
                eUser.Password = EncryptHelper.EncryptString(eUser.Password, "key");
                eUser.Password1 = EncryptHelper.EncryptString(eUser.Password1, "key123");

                this.rpGeneric.SaveOrUpdate<User>(eUser);
                this.rpGeneric.SaveOrUpdate<Request>(eRequest);

                return GetAll();
            }
            catch (Exception ex)
            {
                return ThrowJsonError(ex);
            }

        }
    }
}