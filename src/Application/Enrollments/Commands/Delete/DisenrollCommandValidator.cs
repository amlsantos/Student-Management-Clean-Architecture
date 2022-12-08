using FluentValidation;

namespace Application.Enrollments.Commands.Delete;

public class DisenrollCommandValidator : AbstractValidator<StudentDisenrollmentCommand>
{
    public DisenrollCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
        RuleFor(c => c.Comment).NotEmpty().NotNull();
        RuleFor(c => c.EnrollmentNumber).InclusiveBetween(0, 1);
    }
}