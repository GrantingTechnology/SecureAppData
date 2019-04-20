using gt.business.log;
using gt.enumerator.general;
using System;
using System.Web.Mvc;
//using ...add here the business namespace for the user interface

namespace gt.community.secure
{
    
    public class Utility : Controller
    {

        #region attribute
        internal run gt;
        public string _pathsecure = string.Empty;
        internal bool isAuthenticate = false;
        //internal login_identity infoUser = new login_identity();
        private Invoke.Run.Page _invokepageCurrent = Invoke.Run.Page.indifferent;
        #endregion

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            #region run
            Injected();
            #endregion
        }

        public Utility()
        {

#if !DEBUG
               _pathsecure = "/Secure" ;          
#endif

        }

        /// <summary>
        /// Internal method for population and container customization of gt.business framework [layer .. [current]]
        /// </summary>
        internal void Injected()
        {
            gt.HeadPage(_invokepageCurrent);
            ViewBag.Title = gt.Title;
            ViewBag.MetaDescription = gt.MetaDescription;
            ViewBag.MetaRobots = gt.metaRobot;
            ViewBag.pathRelactive = _pathsecure;
            //ViewBag.gt_headlink = gt.gt_headlink;
            //ViewBag.gt_headscript = gt.gt_headscript;
            //ViewBag.gt_footercript = gt.gt_footercript;
            ViewBag.toAlert = string.Empty;
        }

    }


}