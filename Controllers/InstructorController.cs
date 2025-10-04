using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;
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
            var instructors = db.Instructors
                      .Select(ins => new InswithDeptsVM
                      {
                          SSN = ins.SSN,
                          Name = ins.Name,
                          Address = ins.Address,
                          Salary = ins.Salary,
                          Age = ins.Age,
                          Degree = ins.Degree,
                          DeptId = ins.DepartId,
                          DeptName = ins.Department.Name
                          
                      })
                      .ToList();

            //return View("getall", instructors);
            //var instructors = db.Instructors.ToList();
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
         
            
            return View("NewIns", _instfromreq);
        }

        public IActionResult EditIns(int ssn)
        {

            var ins = db.Instructors.FirstOrDefault(i => i.SSN == ssn);
            InswithDeptsVM insvm = new InswithDeptsVM
            {
                SSN = ins.SSN,
                Name = ins.Name,
                Address = ins.Address,
                Salary = ins.Salary,
                Age = ins.Age,
                Degree = ins.Degree,
                DeptId = ins.DepartId,
                departments = db.Departments.ToList()

            };
            return View(insvm);
        }

        public IActionResult SaveEdit(InswithDeptsVM _instfromreq)
        {
            var ins = db.Instructors.FirstOrDefault(i => i.SSN == _instfromreq.SSN);
            if (ins != null)
            {
                ins.Name = _instfromreq.Name;
                ins.Address = _instfromreq.Address;
                ins.Salary = _instfromreq.Salary;
                ins.Age = _instfromreq.Age;
                ins.Degree = _instfromreq.Degree;
                ins.DepartId = _instfromreq.DeptId;
                db.SaveChanges();
                return RedirectToAction(nameof(getall));
            }
            return View("EditIns", _instfromreq);
        }
    }
}
