using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.context
{
    public class CompanyContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=HAIDY\\SQLEXPRESS;database=tantamvcdb;trusted_connection=true;encrypt=false");
        }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
    }
}
