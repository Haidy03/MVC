using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using WebApplication1.Models;

namespace WebApplication1.Filters
{
    public class CheckDepartmentLocationFilter: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            if (context.ActionArguments.TryGetValue("dept", out var value) && value is Department department)
            {
               if (department.Location != "EG" && department.Location != "USA")
                {
                    context.Result = new ContentResult
                    {
                        Content = "Invalid Location it must be 'EG' or 'USA' only try again",
                        StatusCode = 400
                    };
                }
            }

            base.OnActionExecuting(context);
        }
    }
}
