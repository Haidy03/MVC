using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Controllers
{
    public class DepartmentController : Controller
    {
        CompanyContext db = new CompanyContext();
        //public ContentResult getall()
        // {
        //     //Declare object of ContentResult
        //     ContentResult res = new ContentResult();
        //     //Initialize ContentResult properties
        //     res.Content = "Hello from DepartmentController";
        //     //return
        //     return res;
        //}
        public IActionResult getall()
        {
            var depts = db.Departments.ToList();
            return View("index", depts);
        }
        public JsonResult getjson()
        {
            JsonResult js = new JsonResult(new { name = "haidy", age = 22 });
            return js;
        }

        public ViewResult getview()
        {
            ViewResult vr = new ViewResult();
            vr.ViewName = "test";
            return vr;
        }

        //Department/mix?id=1
        public IActionResult mix(int id)
        {
            if (id == 1)
            {
                //ViewResult vr = new ViewResult();
                //vr.ViewName = "test";
                //return vr;
                return View("test");
            }
            else
            {
                JsonResult js = new JsonResult(new { name = "haidy", age = 22 });
                return js;
            }
        }

        //department/getAllVM
        public IActionResult getAllVM()
        {

            var dept = db.Departments.Select(d =>
            new DepartmentVM
            {
                deptName = d.Name,
                deptManager = d.Manager,
                stdcount = d.Students.Count,
                Inscount = d.Instructors.Count,
                instNames = d.Instructors.Select(i => i.Name).ToList(),
                stdNames = d.Students.Select(s => s.Name).ToList(),

            }).ToList();
            return View("getAllVM", dept);
        }

    }
    }
