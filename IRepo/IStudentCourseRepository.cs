using WebApplication1.Models;

namespace WebApplication1.IRepo
{
    public interface IStudentCourseRepository
    {
        public List<StudentCourse> GetByStudentId(int ssn);
      
    }
}
