using FluentValidation;

namespace Application.UseCases.Enrollments.Commands.Create;

public class EnrollCommandValidator : AbstractValidator<StudentEnrollCommand>
{
    public EnrollCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
        RuleFor(c => c.Course).NotEmpty().NotNull();
        RuleFor(c => c.Grade).NotEmpty().NotNull();
    }
}