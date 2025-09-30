using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class Instructor
    {
        [Key]
        public int SSN { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public float Degree { get; set; }

        [ForeignKey("Department")]
        public int DepartId { get; set; }
        public virtual Department Department { get; set; } 
        public virtual List<Course> Courses { get; set; } = new List<Course>();

    }
}
