namespace WebApplication1.Models.ViewModel
{
    public class studdeptcourwithstdcrsVM
    {
        public string StdName { get; set; }
        public string DeptName { get; set; }

        
        public List<StudentCourse> StudentCourses { get; set; } = new List<StudentCourse>();
        public string crsname { get; set; }
        public float MinDegree { get; set; }
    }
}
