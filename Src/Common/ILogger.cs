// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;

namespace Binance.Common
{
    /// <summary>Defines logging severity levels.</summary>
    /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel?view=netstandard-2.0">`LogLevel` on docs.microsoft.com</a></footer>
    public enum LogLevel
    {
        /// <summary>Logs that contain the most detailed messages. These messages may contain sensitive application data.
        /// These messages are disabled by default and should never be enabled in a production environment.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Trace?view=netstandard-2.0">`LogLevel.Trace` on docs.microsoft.com</a></footer>
        Trace,

        /// <summary>Logs that are used for interactive investigation during development.  These logs should primarily contain
        /// information useful for debugging and have no long-term value.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Debug?view=netstandard-2.0">`LogLevel.Debug` on docs.microsoft.com</a></footer>
        Debug,

        /// <summary>Logs that track the general flow of the application. These logs should have long-term value.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Information?view=netstandard-2.0">`LogLevel.Information` on docs.microsoft.com</a></footer>
        Information,

        /// <summary>Logs that highlight an abnormal or unexpected event in the application flow, but do not otherwise cause the
        /// application execution to stop.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Warning?view=netstandard-2.0">`LogLevel.Warning` on docs.microsoft.com</a></footer>
        Warning,

        /// <summary>Logs that highlight when the current flow of execution is stopped due to a failure. These should indicate a
        /// failure in the current activity, not an application-wide failure.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Error?view=netstandard-2.0">`LogLevel.Error` on docs.microsoft.com</a></footer>
        Error,

        /// <summary>Logs that describe an unrecoverable application or system crash, or a catastrophic failure that requires
        /// immediate attention.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.Critical?view=netstandard-2.0">`LogLevel.Critical` on docs.microsoft.com</a></footer>
        Critical,

        /// <summary>Not used for writing log messages. Specifies that a logging category should not write any messages.</summary>
        /// <footer><a href="https://docs.microsoft.com/en-us/dotnet/api/Microsoft.Extensions.Logging.LogLevel.None?view=netstandard-2.0">`LogLevel.None` on docs.microsoft.com</a></footer>
        None,
    }

    public interface ILogger
    {
        void Log<TState>(
            LogLevel logLevel,
            TState state,
            Exception exception);

        bool IsEnabled(LogLevel logLevel);

        IDisposable BeginScope<TState>(TState state);
    }

    public static class LoggerExtensions
    {
        class FormattedLogValue
        {
            private readonly string _format;
            private readonly object[] _args;

            public FormattedLogValue(string msg, object[] args)
            {
                _format = msg;
                this._args = args;
            }

            public override string ToString()
            {
                if (this._args != null && this._args.Length > 0)
                {
                    return string.Format(this._format, this._args);
                }

                return this._format;
            }
        }

        public static void LogInformation(this ILogger logger, string message, params object[] args) =>
            logger.Log(LogLevel.Information, new FormattedLogValue(message, args), null);

        public static void LogWarning(this ILogger logger, string message, params object[] args) =>
            logger.Log(LogLevel.Warning, new FormattedLogValue(message, args), null);

        public static void LogError(this ILogger logger, string message, params object[] args) =>
            logger.Log(LogLevel.Error, new FormattedLogValue(message, args), null);
    }
}