namespace WebApplication1.Models.ViewModel
{
    public class DepartmentVM
    {
        public string deptName { get; set; }
        public string deptManager { get; set; }
        public int stdcount { get; set; }
        public int Inscount { get; set; }
        public List<string> instNames { get; set; }
        public List<string> stdNames { get; set; }
       
    }
}
