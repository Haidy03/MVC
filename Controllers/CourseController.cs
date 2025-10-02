using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        CompanyContext db = new CompanyContext();

        // /Course/getAll
        public IActionResult getAll()
        {
            var courses = db.Courses.ToList();
            return View("getallcourses",courses);
        }

        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Course coursefromrequest)
        {
            if(coursefromrequest.Name != null && coursefromrequest.Topic != null)
            {
                db.Courses.Add(coursefromrequest);
                db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }
            return View("New", coursefromrequest);
        }

        public IActionResult Edit(int ssn)
        {
            var course = db.Courses.FirstOrDefault(c => c.Num == ssn);
            if (course == null)
            {
                return NotFound(); 
            }
            return View("Edit", course);
        }

        [HttpPost]
        public IActionResult SaveEdit(Course coursefromreq) 
        {
           
            if (coursefromreq.Name != null && coursefromreq.Topic != null) 
            {
                var coursefromdb = db.Courses.FirstOrDefault(c => c.Num == coursefromreq.Num);
                coursefromdb.Name=coursefromreq.Name;
                coursefromdb.Topic=coursefromreq.Topic;
                db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }
            return View("Edit", coursefromreq);
        }

    }
}
