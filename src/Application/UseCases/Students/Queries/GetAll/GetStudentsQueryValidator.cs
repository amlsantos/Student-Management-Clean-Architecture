using FluentValidation;

namespace Application.UseCases.Students.Queries.GetAll;

public class GetStudentsQueryValidator : AbstractValidator<GetStudentsQuery>
{
    public GetStudentsQueryValidator()
    {
        RuleFor(c => c.EnrolledIn).NotEmpty().NotNull();
        RuleFor(c => c.NumberOfCourses).NotEmpty().NotNull();
        RuleFor(c => c.NumberOfCourses).LessThan(3);
    }
}