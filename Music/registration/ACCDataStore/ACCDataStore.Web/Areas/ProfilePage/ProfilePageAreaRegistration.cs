using System.Web.Mvc;

namespace ACCDataStore.Web.Areas.ProfilePage
{
    public class ProfilePageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "ProfilePage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "ProfilePage_default",
                "ProfilePage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}