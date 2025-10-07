using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApplication1.Filters
{
    public class CheckUserFilter : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var userType = context.HttpContext.Request.Query["UserType"].ToString();

            if (userType != "Student")
            {
                context.Result = new ContentResult
                {
                    Content = "Unauthorized Access — You are not a Student!",
                    StatusCode = 401
                };
            }
        }
    }
}
