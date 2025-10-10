using System.Runtime.Intrinsics.X86;
using WebApplication1.context;
using WebApplication1.IRepo;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.Repository
{
    public class InstructorRepository: IInstructorRepository
    {
        CompanyContext db;

        public InstructorRepository(CompanyContext context)
        {
            db = context;                                   //new CompanyContext();
        }

        // CRUD Operations
        public List<Instructor> GetAll()
        {
            return db.Instructors.ToList();
        }

       
        public void Add(Instructor instructor)
        {

            db.Instructors.Add(instructor);
        }
        public void Update(Instructor instructor)
        {
            db.Instructors.Update(instructor);
        }
        public void Delete(int ssn)
        {
            var ins = GetById(ssn);
            db.Remove(ins);
        }

        public Instructor GetById(int id)
        {
            return db.Instructors.FirstOrDefault(i => i.SSN == id);
        }

        public List<InswithDeptsVM> inswithDeptsVMs()
        {
            var ins = db.Instructors
                .Select(i => new InswithDeptsVM
                {
                    SSN = i.SSN,
                    Name = i.Name,
                    Address = i.Address,
                    Salary = i.Salary,
                    Age = i.Age,
                    Degree = i.Degree,
                    DeptId = i.DepartId,
                    DeptName = i.Department.Name
                }).ToList();
            return ins;
        }

        public InswithDeptsVM GetInstructorWithDepartments(int ssn)
        {
            var ins = GetById(ssn);

            if (ins == null)
                return null;

            var insvm = new InswithDeptsVM
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

            return insvm;
        }

        public void UpdateInstructor(InswithDeptsVM model)
        {
            var ins = db.Instructors.FirstOrDefault(i => i.SSN == model.SSN);
            if (ins != null)
            {
                ins.Name = model.Name;
                ins.Address = model.Address;
                ins.Salary = model.Salary;
                ins.Age = model.Age;
                ins.Degree = model.Degree;
                ins.DepartId = model.DeptId;

                
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
    }
}
