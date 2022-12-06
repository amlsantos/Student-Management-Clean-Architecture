using System.Diagnostics;
using System.Text.Json;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Behaviours;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class, IRequest<TResponse>
{
    private readonly ILogger<TRequest> _logger;

    public LoggingBehavior(ILogger<TRequest> logger) => _logger = logger;

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var requestName = request.GetType().Name;
        var requestGuid = Guid.NewGuid().ToString();
        var requestNameWithGuid = $"{requestName} [{requestGuid}]";

        _logger.LogInformation($"[START] {requestNameWithGuid}");
        TResponse response = default;

        var stopwatch = Stopwatch.StartNew();
        try
        {
            try
            {
                _logger.LogInformation($"[PROPS] {requestNameWithGuid} {JsonSerializer.Serialize(request)}");
            }
            catch (NotSupportedException)
            {
                _logger.LogInformation($"[Serialization ERROR] {requestNameWithGuid} Could not serialize the request.");
            }

            response = await next();
        }
        finally
        {
            _logger.LogInformation($"[RESPONSE] {response.ToString()};");
            stopwatch.Stop();
            _logger.LogInformation($"[END] {requestNameWithGuid}; Execution time={stopwatch.ElapsedMilliseconds}ms");
        }

        return response;
    }
}