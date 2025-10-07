using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Filters;
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

        public IActionResult addnew()
        {
            return View("addnew");
        }

        [HttpPost]
        public IActionResult SaveNew(Department dept)
        {
            //if(dept.Name != null && dept.Manager!=null)
            if(ModelState.IsValid)
            {
                db.Departments.Add(dept);
                db.SaveChanges();
                return RedirectToAction(nameof(getall));
            }
            return View("addnew", dept);
        }

        public IActionResult Edit(int id)
        {
            var dept = db.Departments.FirstOrDefault(d => d.ID == id);
            return View("edit", dept);
        }

        [HttpPost]
        public IActionResult saveedit(Department deptfromrequest)
        {
            //if (deptfromrequest.Name != null && deptfromrequest.Manager != null)
            if (ModelState.IsValid)
              {
                var deptfromdb = db.Departments.FirstOrDefault(d => d.ID == deptfromrequest.ID);
                deptfromdb.Name = deptfromrequest.Name;
                deptfromdb.Manager = deptfromrequest.Manager;   
                db.SaveChanges();
                return RedirectToAction(nameof(getall));
            }
            return View("edit", deptfromrequest);
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

        public IActionResult Add2()
        {
            return View();
        }

        [HttpPost]
        [CheckDepartmentLocationFilter]
        [AddFooterFilter]
        public IActionResult Add2(Department dept)
        {
            db.Departments.Add(dept);
            db.SaveChanges();
            // return RedirectToAction("GetAll");                                 uncomment this to check the [CheckDepartmentLocationFilter] 
            return Content($"Department '{dept.Name}' created successfully!");
        }

    }
    }
