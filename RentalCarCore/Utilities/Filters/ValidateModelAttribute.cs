using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Web.Http.ModelBinding;

namespace RentalCarCore.Utilities.Filters
{
    public class ValidateModelAttribute:ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Response = context.Request.CreateResponse(HttpStatusCode.BadRequest, new ValidationModelResult(context.ModelState));
            }
            base.OnActionExecuting(context);
        }

        private class ValidationModelResult : IValitionAttribute
        {

            [JsonIgnore]
            public HttpStatusCode Status { get; set; }
            [JsonIgnore]
            public string ErrorMessage { get; set; }
            public IEnumerable<IValidationError> Errors { get; set; }
            public ValidationModelResult()
            {
                ErrorMessage = "Validation Failed";
                Status = HttpStatusCode.BadRequest;
            }

            public ValidationModelResult(ModelStateDictionary modelState) : this()
            {
                Errors = modelState.Keys.
                        SelectMany(key => modelState[key]
                        .Errors.GroupBy(x => x.ErrorMessage)
                        .Select(x => new ValidationError(key, x.First().ErrorMessage)));
            }
        }
    }
}
