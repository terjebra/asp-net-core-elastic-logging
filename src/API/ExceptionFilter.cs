using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace API
{
    public class ExceptionFilter: ActionFilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            context.HttpContext.Response.StatusCode =  (int)System.Net.HttpStatusCode.BadRequest;
        }
    }
}