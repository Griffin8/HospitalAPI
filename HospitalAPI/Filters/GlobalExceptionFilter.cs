using System;
using NLog;
using System.Web.Http.Controllers;
using System.Web.Http;
using System.Web.Http.Tracing;
using HospitalAPI.Helper;
using System.Web.Http.Filters;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Net;

namespace HospitalAPI.Filters
{
    /// <summary>
    /// 
    /// </summary>
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        /// <summary>
        /// Handel exception globally and log the exception
        /// </summary>
        /// <param name="context"></param>
        public override void OnException(HttpActionExecutedContext context)
        {
            //NLogger implements ITraceWriter. We want the ServicesContainer use the NLogger instead of ITraceWriter
            GlobalConfiguration.Configuration.Services.Replace(typeof(ITraceWriter), new NLogger());

            var trace = GlobalConfiguration.Configuration.Services.GetTraceWriter();
            trace.Error(context.Request, "Controller : " + context.ActionContext.ControllerContext.ControllerDescriptor.ControllerType.FullName + Environment.NewLine + "Action : " + context.ActionContext.ActionDescriptor.ActionName, context.Exception);

            var exceptionType = context.Exception.GetType();

            if (exceptionType == typeof(ValidationException))
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) { Content = new StringContent(context.Exception.Message), ReasonPhrase = "ValidationException", };
                throw new HttpResponseException(resp);
            }
            else if (exceptionType == typeof(UnauthorizedAccessException))
            {
                throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.Unauthorized));
            }
            else
            {
                throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.InternalServerError));
            }
        }
    }
}