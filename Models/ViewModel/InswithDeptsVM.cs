namespace WebApplication1.Models.ViewModel
{
    public class InswithDeptsVM
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public int Salary { get; set; }
        public int Age { get; set; }
        public float Degree { get; set; }

        public List<Department> departments { get; set; }=new List<Department>();
    }
}
