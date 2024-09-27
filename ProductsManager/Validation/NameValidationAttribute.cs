using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace ProductsManager.Validation
{
    public class NameValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var name = value as string;
            if(string.IsNullOrEmpty(name))
            {
                return new ValidationResult("Name of product is required");
            }

            if(name.Length <5 || name.Length > 30)
            {
                return new ValidationResult("Name of product should be between 5 and 30 characters");
            }
            if(!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
            {
                return new ValidationResult("Name can only contain letters");
            }
            return ValidationResult.Success;
        }
    }
}
