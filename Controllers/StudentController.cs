using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult getall()
        {
            var students = db.Students.ToList();
            return View("index", students);
        }
        public IActionResult getOne(int id)
        {
            var student= db.Students.Find(id);
            return View("studentdetails", student);
        }
    }
}
