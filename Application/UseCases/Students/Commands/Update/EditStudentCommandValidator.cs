using FluentValidation;

namespace Application.UseCases.Students.Commands.Update;

public class EditStudentCommandValidator : AbstractValidator<EditStudentCommand>
{
    public EditStudentCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();

        RuleFor(c => c.Email).NotEmpty().NotNull();
        RuleFor(c => c.Email).EmailAddress();

        RuleFor(c => c.Name).NotEmpty().NotNull();
    }
}