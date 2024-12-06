using FluentValidation.Results;

namespace Greenmaster.Application.Exceptions;

public class ValidationException : Exception
{
    public List<string> ValidationErrors { get; set; }
    
    public ValidationException(ValidationResult validationResult)
    {
        ValidationErrors = [];
        
        foreach (var error in validationResult.Errors)
        {
            ValidationErrors.Add(error.ErrorMessage);
        }
    }
}