using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class GlobalExceptionHandleFilter : Attribute, IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var result = new ContentResult();

            result.Content = $"Global Exception Caught!\n";

            result.ContentType = "text/plain";

            context.ExceptionHandled = true;
            context.Result = result;
        }
    }
}
