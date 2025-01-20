using CrimeVault.Domain.Abstractions;

namespace CrimeVault.Application.Common.Behaviors
{
    public class ValidationBehaviorBase
    {

        private TResult CreateValidationResult<TResult>(List<Error> errors) where TResult : Result
        {
            if (typeof(TResult) == typeof(Result))
            {
                return (TResult)(object)Result.Failure(errors);
            }

            // Use reflection to call the generic Result<T>.Failure method
            var resultType = typeof(Result<>).MakeGenericType(typeof(TResult).GenericTypeArguments[0]);
            var failureMethod = resultType.GetMethod("Failure", [typeof(List<Error>)]);

            if (failureMethod == null)
            {
                throw new InvalidOperationException("Failure method not found.");
            }

            var validationResult = failureMethod.Invoke(null, [errors]);
            if (validationResult == null)
            {
                throw new InvalidOperationException("Validation result is null.");
            }

            return (TResult)validationResult;
        }
    }
}