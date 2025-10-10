using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using WebApplication1.context;
using WebApplication1.Filters;
using WebApplication1.IRepo;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller
    {
        //CompanyContext db = new CompanyContext();

        IStudentRepository studentRepository;
        IDepartmentRepository deptRepo;
        IStudentCourseRepository studentCourseRepo;

        public StudentController(IStudentRepository studentRepo, IDepartmentRepository departmentRepos, IStudentCourseRepository studentCourseReposs)
        {
            studentRepository=studentRepo;
            deptRepo=departmentRepos;
            studentCourseRepo=studentCourseReposs;
        }

        public IActionResult getall()
        {
            //var students = db.Students.ToList();
            var students = studentRepository.GetAll();
            return View("index", students);
        }
        public IActionResult getOne(int id)
        {
            //var student= db.Students.Find(id);
            var student = studentRepository.GetById(id);
            return View("studentdetails", student);
        }
        //Student/getall
        public IActionResult Add()                 //It will just open the form
        {
            var depts = deptRepo.GetAll();
            ViewBag.department = depts;
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Student std)           
        {
            studentRepository.Add(std);
            studentRepository.Save();  
            //var students = db.Students.ToList();
            //return View("index", students);
            return RedirectToAction(nameof(getall));
      
        }

        public IActionResult edit(int ssn)            
        {
            var std =studentRepository.GetById(ssn);
            return View("editt", std);
        }



        [HttpPost]
        public IActionResult SaveEdit(Student stdfromrequest) { 
            
            if (stdfromrequest.Name != null && stdfromrequest.Age > 0 && stdfromrequest.Address != null)
            {
                var stdfromdb = studentRepository.GetById(stdfromrequest.ssn);
                stdfromdb.Name = stdfromrequest.Name;
                stdfromdb.Age = stdfromrequest.Age;
                stdfromdb.Address = stdfromrequest.Address;
                stdfromdb.Image = stdfromrequest.Image;

                studentRepository.Update(stdfromdb);
                studentRepository.Save();
                return RedirectToAction("getall");
            }
            return View("editt", stdfromrequest);
        }


        public IActionResult Details(int ssn)
        {
            //var student = db.Students.Include(s => s.Department).FirstOrDefault(s => s.ssn == ssn);
            //var studentCourses = db.StudentCourses.Where(sc => sc.studentId == ssn).Include(sc => sc.Course).ToList();
            //var courseNames = studentCourses.Select(sc => sc.Course.Name).ToList();
            //var std = new studdeptcourwithstdcrsVM()
            //{
            //    StdName = student.Name,
            //    DeptName = student.Department?.Name,
            //    StudentCourses = studentCourses,
            //    crsname = string.Join(", ", courseNames),

            //};
            var student = studentRepository.GetByIdWithDept(ssn);
            var studentCourses = studentCourseRepo.GetByStudentId(ssn);
            if (student == null)
                return NotFound();
            var courseNames = studentCourses
             .Select(sc => sc.Course.Name)
             .ToList();
            var std = new studdeptcourwithstdcrsVM()
            {
                StdName = student.Name,
                DeptName = student.Department?.Name,
                StudentCourses = studentCourses,
                crsname = string.Join(", ", courseNames),
            };
            return (View("Details", std));
        }

        [CheckUserFilter]
        public IActionResult TestFilter()
        {
            return Content("Welcome You have access to this page");
        }

        public IActionResult Delete(int ssn)
        {
            var inst = studentRepository.GetById(ssn);
            if (inst == null)
            {
                return NotFound();
            }
            else
            {
                studentRepository.Delete(ssn);
                studentRepository.Save();
                return RedirectToAction(nameof(getall));
            }
        }
    }
}
