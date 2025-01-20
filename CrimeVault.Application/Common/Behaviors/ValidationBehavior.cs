using CrimeVault.Application.Common.Errors;
using CrimeVault.Domain.Abstractions;
using FluentValidation;
using MediatR;
using System.Net;

namespace CrimeVault.Application.Common.Behaviors;

public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse> where TResponse : Result
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        _validators = validators;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (!_validators.Any())
        {
            return await next();
        }
        List<Error> errors = _validators.Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null).
            Select(failure => HttpStatusCode.BadRequest.ToError(failure.ErrorMessage)).ToList();

        if (errors.Count != 0)
        {
            return CreateValidationResult<TResponse>(errors);
        }
        return await next();
    }

    private static TResult CreateValidationResult<TResult>(List<Error> errors) where TResult : Result
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




