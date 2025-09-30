using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;

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
        //Student/add
        public IActionResult Add()                 //It will just open the form
        {
            return View();
        }

        public IActionResult AddNew(Student std)           
        {
            db.Students.Add(std);
            db.SaveChanges();
            //var students = db.Students.ToList();
            //return View("index", students);
            return RedirectToAction(nameof(getall));
      
        }
    }
}
