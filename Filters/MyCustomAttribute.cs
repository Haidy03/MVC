using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class MyCustomAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
         
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            
        }
    }
}
