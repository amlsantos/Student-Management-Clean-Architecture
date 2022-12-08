using FluentValidation;

namespace Application.Enrollments.Commands.Update;

public class TransferCommandValidator : AbstractValidator<StudentTransferCommand>
{
    public TransferCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotNull();
        RuleFor(c => c.Course).NotEmpty().NotNull();
        RuleFor(c => c.EnrollmentNumber).InclusiveBetween(0, 1);
        RuleFor(c => c.Grade).NotEmpty();
    }
}