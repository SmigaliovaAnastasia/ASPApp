using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPApp.Common.Exceptions
{
    public class ApiExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            if (context.Exception is ApiException apiException)
            {
                context.Result = new ObjectResult(apiException.Message) { StatusCode = (int)apiException.StatusCode };
            }
        }
    }

}
