﻿using FluentValidation;

namespace Application.Courses.Queries.ByName;

public class GetCourseByNameQueryValidator : AbstractValidator<GetCourseByNameQuery>
{
    public GetCourseByNameQueryValidator()
    {
        RuleFor(c => c.Name).NotEmpty();
        RuleFor(c => c.Name).NotNull();
    }
}