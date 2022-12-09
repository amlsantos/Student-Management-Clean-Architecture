using MediatR;
using Microsoft.Extensions.Logging;
using StudentManagementSystem.Exceptions;

namespace Application.Behaviours;

public class RetryBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : class, IRequest<TResponse>
{
    private const int RetryAttempts = 3;
    private readonly ILogger<TRequest> _logger;
    public RetryBehaviour(ILogger<TRequest> logger) => _logger = logger;

    public async Task<TResponse?> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = request.GetType().Name;
        var requestGuid = Guid.NewGuid().ToString();
        var requestNameWithGuid = $"{requestName} [{requestGuid}]";

        return await TryExecute(next, requestNameWithGuid);
    }

    private async Task<TResponse?> TryExecute(RequestHandlerDelegate<TResponse> next, string requestName)
    {
        TResponse? response = default;
        
        for (var i = 1; i <= RetryAttempts; i++)
        {
            try
            {
                response = await next();
                break;
            }
            catch (Exception e)
            {
                _logger.LogWarning($"[Retrying the request] {requestName} {i} times");

                if (i != RetryAttempts)
                    continue;

                var message = $"[FAILED] [Retrying the request] {requestName} [{RetryAttempts}] times";
                _logger.LogError(message);
                throw new BadRequestException("Bad Request", message, e);
            }
        }

        return response;
    }
}