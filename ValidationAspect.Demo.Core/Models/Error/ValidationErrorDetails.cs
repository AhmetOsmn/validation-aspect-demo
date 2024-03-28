using FluentValidation.Results;

namespace ValidationAspect.Demo.Core.Models.Error
{
    public class ValidationErrorDetails : ErrorDetails
    {
        public IEnumerable<ValidationFailure>? Errors { get; set; }
    }
}
