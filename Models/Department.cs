using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public class Department
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Manager Name is Required")]
        public string Manager { get; set; }


        //nav prop
        public virtual List<Student> Students { get; set; }=new List<Student>();
        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
