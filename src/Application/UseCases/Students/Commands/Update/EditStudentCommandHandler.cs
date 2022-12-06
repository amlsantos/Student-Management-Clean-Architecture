using Application.Interfaces.Messaging;
using Application.Interfaces.Persistence;
using CSharpFunctionalExtensions;
using MediatR;

namespace Application.UseCases.Students.Commands.Update;

public class EditStudentCommandHandler : ICommandHandler<EditStudentCommand, Result>
{
    private readonly IUnitOfWork _unitOfWork;

    public EditStudentCommandHandler(IUnitOfWork unitOfWork) => _unitOfWork = unitOfWork;

    public async Task<Result> Handle(EditStudentCommand command, CancellationToken cancellationToken)
    {
        var maybe = await _unitOfWork.Students.GetById(command.Id);
        if (maybe.HasNoValue)
            return Result.Failure($"No student found for Id {command.Id}");

        var student = maybe.Value;
        student.Name = command.Name;
        student.Email = command.Email;

        await _unitOfWork.CommitAsync();
        return Result.Success();
    }
}