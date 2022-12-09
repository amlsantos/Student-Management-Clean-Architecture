using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;

namespace Application.Students.Commands.Delete;

public record UnregisterStudentCommand : ICommand<Result<string>>
{
    public Guid Id { get; init; }
}

public class UnregisterStudentCommandHandler : ICommandHandler<UnregisterStudentCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnregisterStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<string>> Handle(UnregisterStudentCommand request, CancellationToken cancellationToken)
    {
        var maybe = await _unitOfWork.Students.GetById(request.Id);
        if (maybe.HasNoValue)
            return Result.Failure<string>($"No student found for Id {request.Id}");

        var student = maybe.Value;
        await _unitOfWork.Students.Delete(student);
        await _unitOfWork.CommitAsync();

        return Result.Success($"Student with id {request.Id} deleted with success");
    }
}