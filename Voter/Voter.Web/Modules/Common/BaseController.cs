using Voter.Web.Mvc.LoggedUsers;
using NLog;
using NLog.Targets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Web.Mvc;
using Voter.Web.Mvc.Results;
using Voter.Web.Mvc.Activities;

namespace Voter.Web.Modules.Common
{
    /// <summary>
    /// Výchozí controller
    /// </summary>
    public class BaseController : Controller
    {
        #region Fields

        private const string DEFAULT_LANG = "cs";

        #endregion

        #region Properties

        public Logger Logger { get; private set; }

        public ClaimsIdentity UserIdentity { get; set; }

        public ILoggedUser LoggedUser { get; private set; }

        public bool IsPageStateEnabled { get; set; }

        /// <summary>
        /// Seznam funkcí volaných na stránce
        /// </summary>
        public Activity Activity { get; private set; }

        public Uri PreviousUrl
        {
            get { return (Uri)TempData["PreviousUrl"]; }
            protected set { TempData["PreviousUrl"] = value; }
        }

        #endregion

        #region Overrided methods

        public BaseController()
        {
            Logger = LogManager.GetLogger(GetType().FullName);
            LoggedUser = DependencyResolver.Current.GetService<ILoggedUser>();
        }

        protected override IAsyncResult BeginExecuteCore(AsyncCallback callback, object state)
        {
            Activity = new Activity();

            return base.BeginExecuteCore(callback, state);
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            UserIdentity = (ClaimsIdentity)User.Identity;
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var actionDescriptor = filterContext.ActionDescriptor;
            string controllerName = actionDescriptor.ControllerDescriptor.ControllerName;
            string actionName = actionDescriptor.ActionName;
            string userName = filterContext.HttpContext.User.Identity.Name?.ToString();
            DateTime timeStamp = filterContext.HttpContext.Timestamp;
            string routeId = string.Empty;
            if (filterContext.RouteData.Values["id"] != null)
            {
                routeId = filterContext.RouteData.Values["id"].ToString();
            }
            StringBuilder message = new StringBuilder();
            message.Append("UserName=");
            message.Append(userName + "|");
            message.Append("Controller=");
            message.Append(controllerName + "|");
            message.Append("Action=");
            message.Append(actionName + "|");
            message.Append("TimeStamp=");
            message.Append(timeStamp.ToString() + "|");
            if (!string.IsNullOrEmpty(routeId))
            {
                message.Append("RouteId=");
                message.Append(routeId);
            }

            // operace
            if (filterContext.Result is System.Web.Mvc.ViewResultBase)
            {
                if (((System.Web.Mvc.ViewResultBase)filterContext.Result).ViewBag.Activities == null)
                {
                    ((System.Web.Mvc.ViewResultBase)filterContext.Result).ViewBag.Activities = new List<string>();
                }

                var target = LogManager.Configuration.FindTargetByName<MemoryTarget>("mem");
                var logs = target.Logs;
                bool doClear = false;

                var activities = (List<string>)(((System.Web.Mvc.ViewResultBase)filterContext.Result).ViewBag.Activities);
                if (Activity != null && Activity.Stopwatch != null)
                {
                    Activity.Stopwatch.Stop();
                    DateTime dt = DateTime.MinValue.Add(Activity.Stopwatch.Elapsed);
                    activities.Add(string.Format(@"Render time: {0}", dt.ToString("H:mm:ss.fff")));
                    doClear = true;
                }

                activities.AddRange(logs.ToList());
                if (doClear)
                {
                    target.Logs.Clear();
                }
            }

            //if (LoggedUser != null && LoggedUser.IsProlongTime)
            //{
            //    var manager = DependencyResolver.Current.GetService<RefreshLoginHandler>();
            //    manager.Handle(new RefreshLoginModel());
            //}

            Logger.Trace(message.ToString());
            base.OnActionExecuted(filterContext);
        }

        protected override void OnException(ExceptionContext filterContext)
        {
            base.OnException(filterContext);
        }

        #endregion

        #region Protected methods

        protected virtual void SetLanguage(string lang = null)
        {
            if (lang != null && lang != DEFAULT_LANG)
            {
                ControllerContext.RouteData.Values["lang"] = lang;
            }
            else if (ControllerContext.RouteData.Values.ContainsKey("lang"))
            {
                ControllerContext.RouteData.Values.Remove("lang");
            }
        }

        #endregion

        #region AsView methods

        protected virtual ActionResult AsView<TModel>(ModelBuilderResult<TModel> result)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ViewBag.Actions = result.Actions;
            ViewBag.Message = result.Message ?? TempData["Message"];
            ViewBag.IsSuccess = TempData["IsSuccess"] ?? true;

            return View(result.Data);
        }

        protected virtual ActionResult AsView(ModelHandlerResult result, ActionResult successAction, ActionResult failAction = null)
        {
            ViewBag.Message = result.Message;
            ViewBag.IsSuccess = result.IsSuccess;

            if (result.IsSuccess)
            {
                return UseTempDataAction(successAction);
            }

            ModelState.Clear();

            AddValidationMessage(result, failAction);
            ViewBag.Actions = result.Actions;

            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            return UseTempDataAction(failAction) ?? View(result.Data);
        }

        #endregion

        #region AsPartialView methods

        protected virtual PartialViewResult AsPartialView<TModel>(ModelBuilderResult<TModel> result, string partialView)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ViewBag.Actions = result.Actions;
            ViewBag.Message = result.Message;
            return PartialView(partialView, result.Data);
        }

        protected virtual PartialViewResult AsPartialView(ModelHandlerResult result, string partialView)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ViewBag.Message = result.Message;
            ViewBag.Actions = result.Actions;

            if (result.IsSuccess)
            {
                return PartialView(partialView, result.Data);
            }

            ModelState.Clear();

            AddValidationMessage(result, null);
            return PartialView(partialView, result.Data);
        }

        protected virtual PartialViewResult AsPartialView<TModel>(ModelHandlerResult handlerResult, ModelBuilderResult<TModel> builderResult, string partialView)
        {
            HttpContext.Response.StatusCode = (int)HttpStatusCode.OK;
            ViewBag.Message = handlerResult.Message;
            ViewBag.Actions = handlerResult.Actions;

            if (handlerResult.IsSuccess)
            {
                return PartialView(partialView, builderResult.Data);
            }

            ModelState.Clear();

            AddValidationMessage(handlerResult, null);
            return PartialView(partialView, builderResult.Data);
        }

        #endregion

        #region Private methods

        private void AddValidationMessage(ModelHandlerResult result, ActionResult action)
        {
            // projdu seznam validačních hlášek
            StringBuilder sb = new StringBuilder();
            if (result.ValidationMessages != null)
            {
                foreach (var validateMessage in result.ValidationMessages)
                {
                    // nastavím error
                    ModelState.AddModelError(validateMessage.Property, validateMessage.DisplayName);
                    sb.AppendLine(validateMessage.DisplayName).AppendLine(". ");
                }
            }

            if (action != null && !(action is ViewResult) && result.Message == null)
            {
                ViewBag.Message = sb.ToString();
            }
        }

        private ActionResult UseTempDataAction(ActionResult action)
        {
            if (action != null && !(action is ViewResult))
            {
                TempData["Message"] = ViewBag.Message;
                TempData["IsSuccess"] = ViewBag.IsSuccess;
            }
            return action;
        }

        #endregion
    }
}