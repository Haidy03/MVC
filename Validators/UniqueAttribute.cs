using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using WebApplication1.context;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class UniqueAttribute:ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var name = value as string;
            if (string.IsNullOrEmpty(name))
                return ValidationResult.Success;

            var db = new CompanyContext();
            var currentCourse = validationContext.ObjectInstance as Course;

            if (currentCourse == null)
                return ValidationResult.Success;

            
            int courseId = currentCourse.Num;

            var existingCourse = db.Courses.FirstOrDefault(c => c.Name == name && c.Num != courseId);

            if (existingCourse != null)
            {
                return new ValidationResult("Name must be unique");
            }

            return ValidationResult.Success;
        }

    }
}
