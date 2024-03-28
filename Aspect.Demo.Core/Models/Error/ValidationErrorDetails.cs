using FluentValidation.Results;

namespace Aspect.Demo.Core.Models.Error
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
