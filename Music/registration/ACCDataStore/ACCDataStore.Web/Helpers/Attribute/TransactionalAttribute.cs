using ACCDataStore.Web.Helpers.ORM;
using System.Net;
using System.Web.Http;
using System.Web.Mvc;

namespace ACCDataStore.Web.Helpers.Attribute
{
    public class TransactionalAttribute : ActionFilterAttribute
    {
        private IUnitOfWork unitOfWork;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.HttpContext.Error == null)
            {
                unitOfWork = DependencyResolver.Current.GetService<IUnitOfWork>();
            }

            base.OnActionExecuting(filterContext);
        }
        // THis is the original method!

        //public override void OnActionExecuted(ActionExecutedContext filterContext)
        //{
        //    if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.Exception == null && filterContext.HttpContext.Error == null && unitOfWork != null)
        //    {
        //        unitOfWork.Commit();
        //    }

        //    base.OnActionExecuted(filterContext);
        //}

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.ExceptionHandled = true;

            if (filterContext.Controller.ViewData.ModelState.IsValid && filterContext.Exception == null && filterContext.HttpContext.Error == null && unitOfWork != null)
            {
                try
                {
                    unitOfWork.Commit();
                }
                catch (System.Exception ex)
                {
                  
                    //log.Error(ex.Message);

                    if (filterContext.HttpContext.Request.IsAjaxRequest())
                    {
                        filterContext.HttpContext.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        var result = new JsonResult();
                        result.Data = new { Status = 0, Message = "Error while process data, please check log file." };
                        result.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
                        filterContext.Result = result;
                        return;
                    }
                    else
                    {
                        throw new HttpResponseException(HttpStatusCode.BadRequest);
                    }
                }
            }
            else
            {
                foreach (var modelState in filterContext.Controller.ViewData.ModelState.Values)
                {
                    foreach (var error in modelState.Errors)
                    {
                       // log.Error(error.ErrorMessage, error);
                    }
                }
            }

            base.OnActionExecuted(filterContext);
        }
    }
}
