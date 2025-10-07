using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class FilterController : Controller
    {
        [handleError]
        public IActionResult Index()
        {
            throw new Exception("Some error from filter");
        }
    }
}
