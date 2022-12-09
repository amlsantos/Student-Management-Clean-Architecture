using MediatR;

namespace Application.Interfaces.Messaging;

public interface IRetryableRequest<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    int RetryAttempts => 3;
    int RetryDelay => 250;
    bool RetryWithExponentialBackoff => false;
    int ExceptionsAllowedBeforeCircuitTrip => 1;
}