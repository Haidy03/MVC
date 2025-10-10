using Microsoft.EntityFrameworkCore;
using WebApplication1.context;
using WebApplication1.IRepo;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class StudentRepository: IStudentRepository
    {
        CompanyContext db;

        public StudentRepository(CompanyContext context)
        {
            db = context;                         // new CompanyContext();
        }

        // CRUD Operations
        public List<Student> GetAll()
        {
            return db.Students.ToList();
        }
        public void Add(Student std)
        {
            db.Students.Add(std);
        }
        public void Update(Student std)
        {
            db.Students.Update(std);
        }
        public void Delete(int id)
        {
            Student std = GetById(id);
            db.Students.Remove(std);
        }

        public Student GetById(int id)
        {
            return db.Students.FirstOrDefault(s=>s.ssn == id);
        }

        public Student GetByIdWithDept(int ssn)
        {
            return db.Students
                     .Include(s => s.Department)
                     .FirstOrDefault(s => s.ssn == ssn);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
