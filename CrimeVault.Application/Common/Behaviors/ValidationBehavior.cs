using CrimeVault.Application.Common.Errors;
using CrimeVault.Domain.Abstractions;
using FluentValidation;
using MediatR;

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
        var errors = _validators.Select(v => v.Validate(request))
            .SelectMany(result => result.Errors)
            .Where(failure => failure != null).
            Select(failure => new BadRequestError(failure.ErrorMessage)).ToList();
        if (errors.Count != 0)
        {
            return await next();
        }
        return await next();
    }
}




