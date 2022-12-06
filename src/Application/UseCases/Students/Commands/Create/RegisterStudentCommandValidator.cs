using FluentValidation;
using StudentManagementSystem.Entities;

namespace Application.UseCases.Students.Commands.Create;

public class RegisterStudentCommandValidator : AbstractValidator<RegisterStudentCommand>
{
    public RegisterStudentCommandValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).NotNull();
        
        RuleFor(c => c.Email).NotEmpty();
        RuleFor(c => c.Email).NotNull();
        RuleFor(c => c.Email).EmailAddress();
        
        RuleFor(c => c.Course1).NotEmpty().NotNull();
        RuleFor(c => c.Course1Grade).NotEmpty().NotNull();
        RuleFor(c => c.Course1Grade).IsEnumName(typeof(Grade)).WithMessage(c => $"Not a valid grade: {c.Course1Grade}");
        
        RuleFor(c => c.Course2).NotEmpty().NotNull();
        RuleFor(c => c.Course2Grade).NotEmpty().NotNull();
        RuleFor(c => c.Course2Grade).IsEnumName(typeof(Grade)).WithMessage(c => $"Not a valid grade: {c.Course2Grade}");
    }
}