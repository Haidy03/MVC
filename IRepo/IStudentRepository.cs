using WebApplication1.Models;

namespace WebApplication1.IRepo
{
    public interface IStudentRepository
    {
        public List<Student> GetAll();

        public void Add(Student std);

        public void Update(Student std);

        public void Delete(int id);


        public Student GetById(int id);


        public Student GetByIdWithDept(int ssn);


        public void Save();
      
    }
}
