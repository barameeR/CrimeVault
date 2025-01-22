using FluentValidation;

namespace CrimeVault.Application.Services.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(v => v.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("A valid email is required");
        RuleFor(v => v.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters");
        RuleFor(v => v.FirstName)
            .NotEmpty().WithMessage("First Name is required");
        RuleFor(v => v.LastName)
            .NotEmpty().WithMessage("Last Name is required");
    }
}


