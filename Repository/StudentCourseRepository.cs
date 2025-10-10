using Microsoft.EntityFrameworkCore;
using WebApplication1.context;
using WebApplication1.IRepo;
using WebApplication1.Models;

namespace WebApplication1.Repository
{
    public class StudentCourseRepository: IStudentCourseRepository
    {
        CompanyContext db;

        public StudentCourseRepository(CompanyContext context)
        {
            db = context;
        }
        public List<StudentCourse> GetByStudentId(int ssn)
        {
            return db.StudentCourses
                     .Where(sc => sc.studentId == ssn)
                     .Include(sc => sc.Course)
                     .ToList();
        }
    }
}
