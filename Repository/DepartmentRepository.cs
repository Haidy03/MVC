using Microsoft.EntityFrameworkCore;
using WebApplication1.context;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Repository
{
    public class DepartmentRepository
    {
        CompanyContext db;

        public DepartmentRepository()
        {
            db = new CompanyContext();
        }

        // CRUD Operations
        public List<Department> GetAll()
        {
            return db.Departments.ToList();
        }
        public void Add(Department dept)
        {
            db.Departments.Add(dept);
        }
        public void Update(Department dept)
        {
            db.Departments.Update(dept);
        }
        public void Delete(int id)
        {
            Department dept = GetById(id);
            db.Departments.Remove(dept);
        }

        public Department GetById(int id)
        {
            return db.Departments.FirstOrDefault(d=> d.ID == id);
        }

        public List<DepartmentVM> departmentVMs()
        {
            var dept=db.Departments
                .Include(d=>d.Students)
                .Include(d=>d.Instructors)
                .Select(d=> new DepartmentVM
                {
                    deptName=d.Name,
                    deptManager=d.Manager,
                    stdcount=d.Students.Count,
                    Inscount=d.Instructors.Count,
                    instNames = d.Instructors.Select(i => i.Name).ToList(),
                    stdNames = d.Students.Select(s => s.Name).ToList(),
                }).ToList();
            return dept;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
