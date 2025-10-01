using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
        CompanyContext db = new CompanyContext();
        public IActionResult getall()
        {
            var instructors = db.Instructors.ToList();
            return View("getall",instructors);
        }

        public IActionResult NewIns() 
        { 
            var depts = db.Departments.ToList();
            ViewBag.department = depts;
            return View("NewIns");
        }

        public IActionResult SaveNew(Instructor _instfromreq)
        {
            if (_instfromreq.Name != null)
            {
                db.Instructors.Add(_instfromreq);
                db.SaveChanges();
                return RedirectToAction(nameof(getall));
            }
            return View("New", _instfromreq);
        }

        public IActionResult EditIns(int ssn)
        {
            var ins = db.Instructors.FirstOrDefault(i => i.SSN == ssn);
            //InswithDeptsVM insvm = new InswithDeptsVM();
            return View( ins);
        }
    }
}
