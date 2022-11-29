using FluentValidation;

namespace Application.UseCases.Courses.Commands.Create;

public class CreateCourseCommandValidator : AbstractValidator<CreateCourseCommand>
{
    public CreateCourseCommandValidator()
    {
        RuleFor(c => c.Name).NotNull();
        RuleFor(c => c.Name).NotEmpty();
        
        RuleFor(c => c.Credits).NotEmpty();
        RuleFor(c => c.Credits).NotNull();
        RuleFor(c => c.Credits).LessThanOrEqualTo(20);
    }
}