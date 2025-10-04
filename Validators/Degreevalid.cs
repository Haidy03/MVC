using System.ComponentModel.DataAnnotations;
using WebApplication1.Models;

namespace WebApplication1.Validators
{
    public class Degreevalid:ValidationAttribute
    {
        override protected ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var course = (Course)validationContext.ObjectInstance;
            if (course.MinDegree>course.Degree)
            {
                return new ValidationResult("MinDegree must be less than the degree");
            }
            return ValidationResult.Success;
        }
    }
}
