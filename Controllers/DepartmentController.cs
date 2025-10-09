using Microsoft.AspNetCore.Mvc;
using WebApplication1.context;
using WebApplication1.Filters;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;

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

        DepartmentRepository DepartmentRepository= new DepartmentRepository();
        public IActionResult getall()
        {
            var depts = DepartmentRepository.GetAll();
            return View("index", depts);
        }

        public IActionResult delete(int id)
        {
            var dept = DepartmentRepository.GetById(id);
            if (dept != null)
            {
                DepartmentRepository.Delete(id);
                DepartmentRepository.Save();
                return RedirectToAction(nameof(getall));
            }
            else
            {
                return NotFound();
            }
            
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
                DepartmentRepository.Add(dept);
                DepartmentRepository.Save();
                
                return RedirectToAction(nameof(getall));
            }
            return View("addnew", dept);
        }

        public IActionResult Edit(int id)
        {
            var dept = DepartmentRepository.GetById(id);
            return View("edit", dept);
        }

        [HttpPost]
        public IActionResult saveedit(Department deptfromrequest)
        {
            //if (deptfromrequest.Name != null && deptfromrequest.Manager != null)
            if (ModelState.IsValid)
              {
                // var deptfromdb = db.Departments.FirstOrDefault(d => d.ID == deptfromrequest.ID);
                var deptfromdb= DepartmentRepository.GetById(deptfromrequest.ID);
                deptfromdb.Name = deptfromrequest.Name;
                deptfromdb.Manager = deptfromrequest.Manager;   
                DepartmentRepository.Update(deptfromdb);
                DepartmentRepository.Save();
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
            var dept = DepartmentRepository.departmentVMs();
            //var dept =db.Departments.Select(d =>
            //new DepartmentVM
            //{
            //    deptName = d.Name,
            //    deptManager = d.Manager,
            //    stdcount = d.Students.Count,
            //    Inscount = d.Instructors.Count,
            //    instNames = d.Instructors.Select(i => i.Name).ToList(),
            //    stdNames = d.Students.Select(s => s.Name).ToList(),

            //}).ToList();
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
              DepartmentRepository.Add(dept);
              DepartmentRepository.Save();
            // return RedirectToAction("GetAll");                                 uncomment this to check the [CheckDepartmentLocationFilter] 
            return Content($"Department '{dept.Name}' created successfully!");
        }

    }
    }
