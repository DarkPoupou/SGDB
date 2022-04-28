using System.Data.SqlClient;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CleanArchitecture.Application.Common.Behaviours;

public class UnhandledExceptionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly ILogger<TRequest> _logger;

    public UnhandledExceptionBehaviour(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
    {
        try
        {
            return await next();
        }
        catch(SqlException exception)
        {
            switch (exception.Number)
            {
                case 4060:
                    _logger.LogCritical($"the Database specified does not exist on {exception.Server}");
                    break;
                case 18456:
                    _logger.LogCritical($"Bad credentials");
                    break;
                case 487:
                    _logger.LogCritical("Conflict");
                    break;
                default:
                    _logger.LogCritical($"{exception.Number} -- {exception.Message}");
                    break;
            }
            throw;
        }
        catch (Exception ex)
        {
            var requestName = typeof(TRequest).Name;

            _logger.LogError(ex, "CleanArchitecture Request: Unhandled Exception for Request {Name} {@Request}", requestName, request);

            throw;
        }
    }
}
