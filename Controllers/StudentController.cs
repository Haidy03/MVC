using Microsoft.AspNetCore.Mvc;
using System.Net;
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
        //Student/getall
        public IActionResult Add()                 //It will just open the form
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddNew(Student std)           
        {
            db.Students.Add(std);
            db.SaveChanges();
            //var students = db.Students.ToList();
            //return View("index", students);
            return RedirectToAction(nameof(getall));
      
        }

        public IActionResult edit(int ssn)            
        {
            var std = db.Students.FirstOrDefault(s=>s.ssn==ssn);
            return View("editt", std);
        }



        [HttpPost]
        public IActionResult SaveEdit(Student stdfromrequest) { 
            
            if (stdfromrequest.Name != null && stdfromrequest.Age > 0 && stdfromrequest.Address != null)
            {
                var stdfromdb = db.Students.FirstOrDefault(s => s.ssn == stdfromrequest.ssn);
                stdfromdb.Name = stdfromrequest.Name;
                stdfromdb.Age = stdfromrequest.Age;
                stdfromdb.Address = stdfromrequest.Address;
                stdfromdb.Image = stdfromrequest.Image;
                
                db.SaveChanges();
                return RedirectToAction("getall");
            }
            return View("editt", stdfromrequest);
        }

    }
}
