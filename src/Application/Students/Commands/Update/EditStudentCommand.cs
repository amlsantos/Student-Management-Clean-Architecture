using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.Students.Commands.Update;

public record EditStudentCommand : ICommand<Result>
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
}

public class EditStudentCommandHandler : ICommandHandler<EditStudentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(EditStudentCommand request, CancellationToken cancellationToken)
    {
        var maybe = await _unitOfWork.Students.GetById(request.Id);
        if (maybe.HasNoValue)
            return Result.Failure($"No student found for Id {request.Id}");

        var student = maybe.Value;
        student.UpdateDetails(request.Name, request.Email);
        
        await _unitOfWork.CommitAsync();
        return Result.Success();
    }
}