using FluentValidation;

namespace Application.Enrollments.Commands.Create;

public class StudentEnrollCommandValidator : AbstractValidator<StudentEnrollCommand>
{
    public StudentEnrollCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
        RuleFor(c => c.Course).NotEmpty().NotNull();
        RuleFor(c => c.Grade).NotEmpty().NotNull();
    }
}