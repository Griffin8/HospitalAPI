using System;
using NLog;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Tracing;
using HospitalAPI.Helper;

namespace HospitalAPI.Filters
{
    public class LoggingFilterAttribute : System.Web.Http.Filters.ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            //NLogger implements ITraceWriter. We want the ServicesContainer use the NLogger instead of ITraceWriter
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());

            //trace returns a instance of NLogger class
            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Info(actionContext.Request, "Controller : " + actionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + actionContext.ActionDescriptor.ActionName, "JSON", actionContext.ActionArguments);

            //string functionName = actionContext.ActionDescriptor.ControllerDescriptor.ControllerName + '\\' + actionContext.ActionDescriptor.ActionName;

            //if (actionContext.Request.Method == HttpMethod.Post)
            //{
            //    var postData = actionContext.ActionArguments;
            //    //do logging here
            //}

        }
    }
}
