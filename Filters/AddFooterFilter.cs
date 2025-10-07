using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text;

namespace WebApplication1.Filters
{
    public class AddFooterFilter : Attribute, IResultFilter
    {
        public void OnResultExecuted(ResultExecutedContext context)
        {
           
        }

        public void OnResultExecuting(ResultExecutingContext context)
        {
            if (context.Result is ContentResult contentResult)
            {
               
                var footer = $"\n\n---\nGenerated at: {DateTime.Now}";
                contentResult.Content += footer;
              
            }
        }
    }
}
