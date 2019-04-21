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
            Authenticate();
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
            //ViewBag.gt_solutionConfiguration = Debugger.IsAttached ? "debug" : "production";
            ViewBag.toAlert = string.Empty;
        }

        /// <summary>
        /// Get user value, items restricted to user current
        /// </summary>
        /// <param name="authenticData">Object type: String, json data represents</param>
        public void getInfo(string authenticData)
        {
            if (authenticData != null)
                if (authenticData != string.Empty)
                {
                    ModelCollection modelcollection = new ModelCollection();
                    modelcollection.AddModel(authenticData);
                    gt.controlPopulation(ref modelcollection, invokeRoutine.sel_adm_user_authenticate);
                }
        }


        /// <summary>
        /// Security status manager, current user information
        /// </summary>
        private void Authenticate()
        {
            try
            {
                ViewBag.padlock = Settings.gt_secure_img_padlock;
                if (System.Web.HttpContext.Current.Session[Settings.gt_ticketAccess] != null)
                {
                    isAuthenticate = (System.Web.HttpContext.Current.Session[Settings.gt_ticketAccess] == null ? false : true);
                    if (gt.UserName == string.Empty)
                    {
                        ModelCollection modelcollection = new ModelCollection();
                        modelcollection.AddModel(infoUser);
                        modelcollection.AddModel((System.Web.HttpContext.Current.Session[Settings.gt_ticketAccess].ToString()));
                        gt.controlPopulation(ref modelcollection, invokeRoutine.sel_adm_user_authenticate);
                    }
                }

                if (isAuthenticate)
                {
                    ViewBag.padlock = Settings.gt_secure_img_padlock_unlock;
                    ViewBag.UserName = infoUser.name;
                    ViewBag.UserPermission = infoUser.permission_nick;
                }

            }
            catch (Exception ex)
            {
                Register.Log(this, ref ex);
            }
        }
    }
}
