using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class handleErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var viewResult = new ViewResult
            {
                ViewName = "~/Views/Shared/Error.cshtml"
            };
            viewResult.ViewData["ErrorMessage"] = context.Exception.Message;
            context.Result = viewResult;
            context.ExceptionHandled = true;
            //ContentResult result = new ContentResult();
            //result.Content = "An error occurred";
            //context.Result = viewResult;
            //context.ExceptionHandled = true;
        }
    }
}
