using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.IRepo
{
    public interface IInstructorRepository
    {
        public List<Instructor> GetAll();


        public void Add(Instructor instructor);

        public void Update(Instructor instructor);

        public void Delete(int ssn);


        public Instructor GetById(int id);


        public List<InswithDeptsVM> inswithDeptsVMs();


        public InswithDeptsVM GetInstructorWithDepartments(int ssn);


        public void UpdateInstructor(InswithDeptsVM model);

        public void Save();
        
    }
}
