using FluentValidation;

namespace Application.Students.Commands.Delete;

public class UnregisterStudentCommandValidator : AbstractValidator<UnregisterStudentCommand>
{
    public UnregisterStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty();
        RuleFor(c => c.Id).NotNull();
    }
}