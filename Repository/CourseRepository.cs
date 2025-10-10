using WebApplication1.context;
using WebApplication1.IRepo;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class CourseRepository: ICourseRepository
    {
        CompanyContext db;

        public CourseRepository(CompanyContext context)
        {
            db = context;           //new CompanyContext();
        }

        // CRUD Operations
        public List<Course> GetAll()
        {
            return db.Courses.ToList();
        }
        public void Add(Course course)
        {
            db.Courses.Add(course);
        }
        public void Update(Course course)
        {
            db.Courses.Update(course);
        }
        public void Delete(int id)
        {
            Course cs = GetById(id);
            db.Courses.Remove(cs);
        }

        public Course GetById(int id)
        {
            return db.Courses.FirstOrDefault(c => c.Num == id);
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}
