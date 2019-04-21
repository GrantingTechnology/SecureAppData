using gt.business.log;
using System;
using System.Web.Mvc;

namespace gt.community.secure
{
    public class SecureAccess : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            try
            {
                if (HttpContext.Current.Session[Settings.gt_ticketAccess] == null)
                {
                    HttpContext.Current.Response.Redirect(Settings.gt_ticketAccess_sucess);
                }

                base.OnActionExecuting(filterContext);

            }
            catch (Exception e)
            {

                Register.Log(this, ref e);
            }
        }
    }
}
