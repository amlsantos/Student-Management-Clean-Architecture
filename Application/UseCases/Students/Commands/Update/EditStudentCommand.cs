using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Students.Commands.Update;

public record EditStudentCommand : IRequest<Result<EditStudentResponse>>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}

public class EditStudentCommandHandler : IRequestHandler<EditStudentCommand, Result<EditStudentResponse>>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<EditStudentResponse>> Handle(EditStudentCommand command, CancellationToken cancellationToken)
    {
        var maybe = await _unitOfWork.Students.GetById(command.Id);
        if (maybe.HasNoValue)
            return Result.Failure<EditStudentResponse>($"No student found for Id {command.Id}");

        var student = maybe.Value;
        student.Name = command.Name;
        student.Email = command.Email;

        await _unitOfWork.CommitAsync();

        var response = new EditStudentResponse()
        {
            Id = student.Id,
            Name = student.Name,
            Email = student.Email
        };

        return Result.Success(response);
    }
}