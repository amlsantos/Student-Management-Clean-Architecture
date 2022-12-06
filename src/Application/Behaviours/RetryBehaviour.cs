using Application.Interfaces.Messaging;
using MediatR;
using Polly;

namespace Application.Behaviours;

public class RetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private readonly IEnumerable<IRetryableRequest<TRequest, TResponse>> _retryHandlers;

    public RetryBehaviour(IEnumerable<IRetryableRequest<TRequest, TResponse>> retryHandlers) => _retryHandlers = retryHandlers;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var retryHandler = _retryHandlers.FirstOrDefault();
        if (retryHandler == null)
            return await next();

        Policy<TResponse>
            .Handle<Exception>()
            .CircuitBreakerAsync(retryHandler.ExceptionsAllowedBeforeCircuitTrip, TimeSpan.FromMilliseconds(5000),
                (exception, things) => { Console.WriteLine("Circuit Tripped!"); },
                () => { });

        var retryPolicy = Policy<TResponse>
            .Handle<Exception>()
            .WaitAndRetryAsync(retryHandler.RetryAttempts, retryAttempt =>
            {
                var retryDelay = retryHandler.RetryWithExponentialBackoff
                    ? TimeSpan.FromMilliseconds(Math.Pow(2, retryAttempt) * retryHandler.RetryDelay)
                    : TimeSpan.FromMilliseconds(retryHandler.RetryDelay);

                Console.WriteLine($"Retrying, waiting {retryDelay}...");

                return retryDelay;
            });

        return await retryPolicy.ExecuteAsync(async () => await next());
    }
}