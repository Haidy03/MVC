using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Models
{
    public class StudentCourse
    {
     
        public int studentId { get; set; }
        public virtual Student student { get; set; }

       
        public int courseId { get; set; }
        public virtual Course Course { get; set; }

        public float Grade { get; set; }
    }
}
