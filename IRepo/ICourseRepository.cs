using WebApplication1.Models;

namespace WebApplication1.IRepo
{
    public interface ICourseRepository
    {
        public List<Course> GetAll();

        public void Add(Course course);

        public void Update(Course course);

        public void Delete(int id);


        public Course GetById(int id);


        public void Save();
       
    }
}
