using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using WebApplication1.Validators;

namespace WebApplication1.Models
{
    public class Course
    {
        [Key]
        public int Num { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        [Unique(ErrorMessage = "Course name must be unique")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Course topic is required")]
        public string Topic { get; set; }

        //[Remote(action:"CheckDegree",controller: "Course",AdditionalFields = "Degree", ErrorMessage ="Min Degree Not valid")]
        [Degreevalid]
        public float MinDegree { get; set; }
        public float Degree { get; set; }

        public virtual List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
