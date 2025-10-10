using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.IRepo;
using WebApplication1.Models;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class CourseController : Controller
    {
        //CompanyContext db = new CompanyContext();

        ICourseRepository courseRepository;
       public CourseController(ICourseRepository courseRepo)
        {
            courseRepository = courseRepo;
        }

        // /Course/getAll
        public IActionResult getAll()
        {
            var courses =courseRepository.GetAll();
            return View("getallcourses",courses);
        }

        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost]
        public IActionResult SaveNew(Course coursefromrequest)
        {
            //if(coursefromrequest.Name != null && coursefromrequest.Topic != null)
            if(ModelState.IsValid)
            {
                courseRepository.Add(coursefromrequest);
                courseRepository.Save();
                //db.Courses.Add(coursefromrequest);
                //db.SaveChanges();
                return RedirectToAction(nameof(getAll));
            }
            return View("New", coursefromrequest);
        }

        public IActionResult Edit(int ssn)
        {
            //var course = db.Courses.FirstOrDefault(c => c.Num == ssn);
            var course = courseRepository.GetById(ssn);
            if (course == null)
            {
                return NotFound(); 
            }
            return View("Edit", course);
        }

        [HttpPost]
        public IActionResult SaveEdit(Course coursefromreq) 
        {
           
            //if (coursefromreq.Name != null && coursefromreq.Topic != null)
            if (ModelState.IsValid)
                {
               // var coursefromdb = db.Courses.FirstOrDefault(c => c.Num == coursefromreq.Num);
                var coursefromdb = courseRepository.GetById(coursefromreq.Num);
                coursefromdb.Name=coursefromreq.Name;
                coursefromdb.Topic=coursefromreq.Topic;
                coursefromdb.Degree = coursefromreq.Degree;
                coursefromdb.MinDegree = coursefromreq.MinDegree;
                // db.SaveChanges();
                courseRepository.Update(coursefromdb);
                courseRepository.Save();
                return RedirectToAction(nameof(getAll));
            }
            return View("Edit", coursefromreq);
        }

        public IActionResult Details(int ssn)
        {
            //var course = db.Courses.FirstOrDefault(c => c.Num == ssn);
            var course = courseRepository.GetById(ssn);
            if (course == null)
            {
                return NotFound();
            }
            return View("Details", course);
        }

        public IActionResult Delete(int ssn)
        {
            //var course = db.Courses.FirstOrDefault(c => c.Num == ssn);
            var course = courseRepository.GetById(ssn);
            if (course == null)
            {
                return NotFound();
            }
            else
            {
                //db.Courses.Remove(course);
                //db.SaveChanges();
                courseRepository.Delete(ssn);
                courseRepository.Save();
                return RedirectToAction(nameof(getAll));
            }
        }

        //public IActionResult CheckDegree(float MinDegree) {
        //    if(MinDegree<db.Courses.de)
        //}

    }
}
