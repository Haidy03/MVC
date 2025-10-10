using WebApplication1.Models;
using WebApplication1.Models.ViewModel;

namespace WebApplication1.IRepo
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();

        public void Add(Department dept);

        public void Update(Department dept);

        public void Delete(int id);


        public Department GetById(int id);


        public List<DepartmentVM> departmentVMs();

        public void Save();
       
    }
}
