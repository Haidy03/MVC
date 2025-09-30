namespace WebApplication1.Models
{
    public class Department
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Manager { get; set; }


        //nav prop
        public virtual List<Student> Students { get; set; }=new List<Student>();
        public virtual List<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
