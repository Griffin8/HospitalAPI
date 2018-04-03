using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace HospitalAPI.Filters
{
    /* Check the model state before the controller action is invoked
     * Return an HTTP response that contains the validation errors if validation fails. In that case, the controller action is not invoked.
     * This filter is applied to all controllers. It is added to the HttpConfiguration.Filters collection in the WebApiConfig class
    */
    /// <summary>
    /// ValidateModel Attribute
    /// </summary>
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        /// <summary>
        /// Override OnActionExecuting
        /// </summary>
        /// <param name="actionContext"></param>
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ModelState.IsValid == false)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(
                    HttpStatusCode.BadRequest, actionContext.ModelState);
            }

        }
    }
}