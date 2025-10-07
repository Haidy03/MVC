using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class StateController : Controller
    {
        //  --------------------------- Session ---------------------------
        public IActionResult SetSession(string name)
        {
            HttpContext.Session.SetString("Name", name);
            HttpContext.Session.SetInt32("Age", 22);
            return Content("Data Saved");
        }

        // /State/SetSession
        public IActionResult GetSession()
        {
            string? name = HttpContext.Session.GetString("Name");
            int? age = HttpContext.Session.GetInt32("Age");
            return Content($"Name: {name}, Age: {age}");
        }

        //  --------------------------- Cookie ---------------------------
        // /State/SetCookie
        public IActionResult SetCookie()
        {
            HttpContext.Response.Cookies.Append("Name", "Haidy");
            HttpContext.Response.Cookies.Append("Age", "22");
            return Content("Cookie Saved");
        }
        public IActionResult GetCookie()
        {
            string? name = HttpContext.Request.Cookies["Name"];
            string? age = HttpContext.Request.Cookies["Age"];
            return Content($"Name: {name}, Age: {age}");
        }

        //  --------------------------- TempData ---------------------------
        // /State/SetTempData
        public IActionResult SetTempData()
        {
            TempData["Name"] = "Haidy";
            TempData["Age"] = 22;
            return Content("Data Saved");
        }
        public IActionResult GetTempData()
        {
            string? name = TempData["Name"]?.ToString();
            int? age = TempData["Age"] as int?;
            return Content($"Name: {name}, Age: {age}");
        }

        //  --------------------------- Query strings ---------------------------
        // /State/GetQueryString?name=Haidy&age=22
        public IActionResult GetQueryString(string name, int age)
        {
            return Content($"Name: {name}, Age: {age}");
        }

        // ---------------------- 5. HIDDEN FIELDS ----------------------

        // /State/HiddenForm
        public IActionResult HiddenForm()
        {
            return View();
        }

       [HttpPost]
        public IActionResult HiddenForm(string name, int age)
        {
            return Content($"Name: {name}, Age: {age}");
        }

        // ---------------------- Global Exception Handling ----------------------
        // /State/Crash
        public IActionResult Crash()
        {
            throw new Exception("Something went wrong!");
        }
    }
}
