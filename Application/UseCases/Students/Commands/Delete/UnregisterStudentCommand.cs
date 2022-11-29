using Application.Interfaces;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Students.Commands.Delete;

public record UnregisterStudentCommand : IRequest<Result<string>>
{
    public Guid Id { get; init; }
}

public class UnregisterStudentCommandHandler : IRequestHandler<UnregisterStudentCommand, Result<string>>
{
    private readonly IUnitOfWork _unitOfWork;

    public UnregisterStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result<string>> Handle(UnregisterStudentCommand command, CancellationToken cancellationToken)
    {
        var maybe = await _unitOfWork.Students.GetById(command.Id);
        if (maybe.HasNoValue)
            return Result.Failure<string>($"No student found for Id {command.Id}");

        var student = maybe.Value;
        await _unitOfWork.Students.Delete(student);
        await _unitOfWork.CommitAsync();

        return Result.Success($"Student with id {command.Id} deleted with success");
    }
}