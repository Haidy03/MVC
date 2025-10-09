using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Core.Types;
using System.Dynamic;
using System.Runtime.Intrinsics.X86;
using WebApplication1.context;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class InstructorController : Controller
    {
       // CompanyContext db = new CompanyContext();
       InstructorRepository repo = new InstructorRepository();
        DepartmentRepository deptRepo = new DepartmentRepository();
        public IActionResult getall()
        {
            var instructors = repo.inswithDeptsVMs();
            //var instructors = db.Instructors
            //          .Select(ins => new InswithDeptsVM
            //          {
            //              SSN = ins.SSN,
            //              Name = ins.Name,
            //              Address = ins.Address,
            //              Salary = ins.Salary,
            //              Age = ins.Age,
            //              Degree = ins.Degree,
            //              DeptId = ins.DepartId,
            //              DeptName = ins.Department.Name

            //          })
            //          .ToList();

            //return View("getall", instructors);
            //var instructors = db.Instructors.ToList();
            return View("getall",instructors);
        }

        public IActionResult NewIns() 
        {
            var depts = deptRepo.GetAll();
            //var depts = db.Departments.ToList();
            ViewBag.department = depts;

            return View("NewIns");
        }

        public IActionResult SaveNew(Instructor _instfromreq)
        {
  
            if (_instfromreq.Name != null)
            {
                    repo.Add(_instfromreq);
                    repo.Save();
                //db.Instructors.Add(_instfromreq);
                //db.SaveChanges();
                return RedirectToAction(nameof(getall));
            }
         
            
            return View("NewIns", _instfromreq);
        }

        public IActionResult EditIns(int ssn)
        {

            //var ins = repo.GetById(ssn);
            //InswithDeptsVM insvm = new InswithDeptsVM
            //{
            //    SSN = ins.SSN,
            //    Name = ins.Name,
            //    Address = ins.Address,
            //    Salary = ins.Salary,
            //    Age = ins.Age,
            //    Degree = ins.Degree,
            //    DeptId = ins.DepartId,
            //    departments = db.Departments.ToList()

            //};
            var insvm = repo.GetInstructorWithDepartments(ssn);
            if (insvm == null)
                return NotFound();

            return View(insvm);
        }

        public IActionResult SaveEdit(InswithDeptsVM _instfromreq)
        {
            var ins = repo.GetById(_instfromreq.SSN);
            if (ins != null)
            {
                //ins.Name = _instfromreq.Name;
                //ins.Address = _instfromreq.Address;
                //ins.Salary = _instfromreq.Salary;
                //ins.Age = _instfromreq.Age;
                //ins.Degree = _instfromreq.Degree;
                //ins.DepartId = _instfromreq.DeptId;
                repo.UpdateInstructor(_instfromreq);
                repo.Save();
                return RedirectToAction(nameof(getall));
            }
            return View("EditIns", _instfromreq);
        }

        public IActionResult Delete(int ssn)
        {
            var inst = repo.GetById(ssn);
            if (inst == null)
            {
                return NotFound();
            }
            else
            {
                repo.Delete(ssn);
                repo.Save();
                return RedirectToAction(nameof(getall));
            }
        }


    }
}
