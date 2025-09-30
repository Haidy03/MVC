using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        public int Num { get; set; }
        public string Name { get; set; }
        public string Topic { get; set; }

        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
