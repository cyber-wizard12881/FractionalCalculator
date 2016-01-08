using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;
using FractionalCalculator.Loggers;

namespace FractionalCalculator.Filters
{
    public class ValidationFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.ActionArguments.ContainsValue(null))
            {
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest, GetNullResponse());
            }

            else if (!actionContext.ModelState.IsValid)
            {
                Logger.LogError(string.Join(", ",
                actionContext.ModelState.Keys.SelectMany(
                    key => actionContext.ModelState[key].Errors.Select(x => key + ": " + ErrorMessage(x)))));
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.BadRequest, actionContext.ModelState);
            }

        }
        private static string ErrorMessage(ModelError modelError)
        {
            return modelError.Exception?.Message ?? modelError.ErrorMessage;
        }

        private static string GetNullResponse()
        {
            return $"Code = \"InvalidRequest\", Detail = \"Either request is empty or is it is syntactically invalid\"";
        }
    }
}
