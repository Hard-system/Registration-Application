using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.ForgotPassword
{
    public class ForgotPasswordAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ForgotPassword";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ForgotPassword_default",
                "ForgotPassword/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}