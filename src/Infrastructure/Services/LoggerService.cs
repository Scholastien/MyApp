using MyApp.Application.Core.Services;
using NLog.Web;

namespace MyApp.Infrastructure.Services;

public class LoggerService : ILoggerService
{
    // Create nlog.config (lowercase all) file in the root of your project
    private readonly NLog.Logger _logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

    public void LogError(string errorMessage)
    {
        _logger.Error(errorMessage);
    }

    public void LogError(string errorMessage, params object[] args)
    {
        _logger.Error(errorMessage, args);
    }

    public void LogException(Exception ex)
    {
        _logger.Error(ex);
    }

    public void LogInfo(string infoMessage)
    {
        _logger.Info(infoMessage);
    }

    public void LogInfo(string infoMessage, params object[] args)
    {
        _logger.Info(infoMessage, args);
    }
}