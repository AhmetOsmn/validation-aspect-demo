using Castle.DynamicProxy;
using FluentValidation;
using Aspect.Demo.Core.CrossCuttingConcerns.Validation;
using Aspect.Demo.Core.Utilities.Interceptors;

namespace Aspect.Demo.Core.Aspects.Autofac.Validation
{
    public class ValidationAspectAttribute : MethodInterceptionAttribute
    {
        private readonly Type _validatorType;
        public ValidationAspectAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new InvalidOperationException("This is not a validation class.");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
