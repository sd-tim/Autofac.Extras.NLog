namespace AutoFac.NLogAdapter.NetCore20
{
   using System;
   using NLog;

   /// <summary>
   ///    Implementation of ILogger, wrapping NLog.Logger
   /// </summary>
   public class LoggerAdapter: ILogger
   {
      private readonly Logger logger;

      /// <summary>
      ///    Create an adapter class using a Logger instance
      /// </summary>
      /// <param name="logger"></param>
      public LoggerAdapter( Logger logger )
      {
         this.logger = logger;
      }

      /// <summary>
      ///    Occurs when logger configuration changes.
      /// </summary>
      public event EventHandler<EventArgs> LoggerReconfigured
      {
         add => logger.LoggerReconfigured += value;
         remove => logger.LoggerReconfigured -= value;
      }

      public string Name => logger.Name;

      public LogFactory Factory => logger.Factory;

      public bool IsTraceEnabled => logger.IsTraceEnabled;
      public bool IsDebugEnabled => logger.IsDebugEnabled;
      public bool IsInfoEnabled => logger.IsInfoEnabled;
      public bool IsWarnEnabled => logger.IsWarnEnabled;
      public bool IsErrorEnabled => logger.IsErrorEnabled;
      public bool IsFatalEnabled => logger.IsErrorEnabled;

      public bool IsEnabled( LogLevel level )
      {
         return logger.IsEnabled( level );
      }

      public void Log( LogEventInfo logEvent )
      {
         logger.Log( GetType(), logEvent );
      }

      public void Log( Type wrapperType, LogEventInfo logEvent )
      {
         logger.Log( wrapperType, logEvent );
      }

      public void Log<T>( LogLevel level, T value )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, null, value ) );
      }

      public void Log<T>( LogLevel level, IFormatProvider formatProvider, T value )
      {
         Exception e = value as Exception;
         logger.Log( GetType(), new LogEventInfo
                                {
                                   LoggerName = Name,
                                   Level = level,
                                   FormatProvider = formatProvider,
                                   Parameters = new object[] { value },
                                   Exception = e
                                } );
      }

      public void LogException( LogLevel level, string message, Exception exception )
      {
         logger.Log( GetType(), new LogEventInfo { Level = level, LoggerName = Name, Message = message, Exception = exception } );
      }

      public void Log( LogLevel level, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Log( GetType(), new LogEventInfo( level, Name, formatProvider, message, args ) );
      }

      public void Log( LogLevel level, string message )
      {
         logger.Log( GetType(), new LogEventInfo( level, Name, message ) );
      }

      public void Log( LogLevel level, string message, params object[] args )
      {
         logger.Log( GetType(), new LogEventInfo { Level = level, LoggerName = Name, Message = message, Parameters = args } );
      }

      public void Log<TArgument>( LogLevel level, IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Log( GetType(), new LogEventInfo( level, Name, formatProvider, message, new object[] { argument } ) );
      }

      public void Log<TArgument>( LogLevel level, string message, TArgument argument )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, null, null, message, new object[] { argument } ) );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, formatProvider, message, new object[] { argument1, argument2 } ) );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, null, message, new object[] { argument1, argument2 } ) );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, formatProvider, message, new object[] { argument1, argument2, argument3 } ) );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Log( GetType(), LogEventInfo.Create( level, Name, null, message, new object[] { argument1, argument2, argument3 } ) );
      }

      public void Trace<T>( T value )
      {
         Log( LogLevel.Trace, value );
      }

      public void Trace<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Trace, formatProvider, value );
      }

      public void Trace( string message, Exception exception )
      {
         Log( LogLevel.Trace, message, exception );
      }

      public void Trace( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Trace, message, exception, args );
      }

      public void Trace( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Trace, formatProvider, message, exception, args );
      }

      public void Trace( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Trace, formatProvider, message, args );
      }

      public void Trace( string message )
      {
         Log( LogLevel.Trace, message );
      }

      public void Trace( string message, params object[] args )
      {
         Log( LogLevel.Trace, message, args );
      }

      public void Trace<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Trace, formatProvider, message, argument );
      }

      public void Trace<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Trace, message, argument );
      }

      public void Trace<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Trace, formatProvider, message, argument1, argument2 );
      }

      public void Trace<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Trace, message, argument1, argument2 );
      }

      public void Trace<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Trace, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Trace<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Trace, message, argument1, argument2, argument3 );
      }

      public void Debug<T>( T value )
      {
         Log( LogLevel.Debug, value );
      }

      public void Debug<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Debug, formatProvider, value );
      }

      public void Debug( string message, Exception exception )
      {
         Log( LogLevel.Debug, message, exception );
      }

      public void Debug( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Debug, message, exception, args );
      }

      public void Debug( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Debug, formatProvider, message, exception, args );
      }

      public void Debug( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Debug, formatProvider, message, args );
      }

      public void Debug( string message )
      {
         Log( LogLevel.Debug, message );
      }

      public void Debug( string message, params object[] args )
      {
         Log( LogLevel.Debug, message, args );
      }

      public void Debug<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Debug, formatProvider, message, argument );
      }

      public void Debug<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Debug, message, argument );
      }

      public void Debug<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Debug, formatProvider, message, argument1, argument2 );
      }

      public void Debug<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Debug, message, argument1, argument2 );
      }

      public void Debug<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Debug, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Debug<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Debug, message, argument1, argument2, argument3 );
      }

      public void Info<T>( T value )
      {
         Log( LogLevel.Info, value );
      }

      public void Info<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Info, formatProvider, value );
      }

      public void Info( string message, Exception exception )
      {
         Log( LogLevel.Info, message, exception );
      }

      public void Info( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Info, message, exception, args );
      }

      public void Info( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Info, formatProvider, message, exception, args );
      }

      public void Info( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Info, formatProvider, message, args );
      }

      public void Info( string message )
      {
         Log( LogLevel.Info, message );
      }

      public void Info( string message, params object[] args )
      {
         Log( LogLevel.Info, message, args );
      }

      public void Info<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Info, formatProvider, message, argument );
      }

      public void Info<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Info, message, argument );
      }

      public void Info<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Info, formatProvider, message, argument1, argument2 );
      }

      public void Info<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Info, message, argument1, argument2 );
      }

      public void Info<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Info, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Info<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Info, message, argument1, argument2, argument3 );
      }

      public void Warn<T>( T value )
      {
         Log( LogLevel.Warn, value );
      }

      public void Warn<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Warn, formatProvider, value );
      }

      public void Warn( string message, Exception exception )
      {
         Log( LogLevel.Warn, message, exception );
      }

      public void Warn( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Warn, message, exception, args );
      }

      public void Warn( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Warn, formatProvider, message, exception, args );
      }

      public void Warn( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Warn, formatProvider, message, args );
      }

      public void Warn( string message )
      {
         Log( LogLevel.Warn, message );
      }

      public void Warn( string message, params object[] args )
      {
         Log( LogLevel.Warn, message, args );
      }

      public void Warn<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Warn, formatProvider, message, argument );
      }

      public void Warn<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Warn, message, argument );
      }

      public void Warn<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Warn, formatProvider, message, argument1, argument2 );
      }

      public void Warn<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Warn, message, argument1, argument2 );
      }

      public void Warn<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Warn, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Warn<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Warn, message, argument1, argument2, argument3 );
      }

      public void Error<T>( T value )
      {
         Log( LogLevel.Error, value );
      }

      public void Error<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Error, formatProvider, value );
      }

      public void Error( string message, Exception exception )
      {
         Log( LogLevel.Error, message, exception );
      }

      public void Error( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Error, message, exception, args );
      }

      public void Error( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Error, formatProvider, message, exception, args );
      }

      public void Error( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Error, formatProvider, message, args );
      }

      public void Error( string message )
      {
         Log( LogLevel.Error, message );
      }

      public void Error( string message, params object[] args )
      {
         Log( LogLevel.Error, message, args );
      }

      public void Error<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Error, formatProvider, message, argument );
      }

      public void Error<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Error, message, argument );
      }

      public void Error<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Error, formatProvider, message, argument1, argument2 );
      }

      public void Error<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Error, message, argument1, argument2 );
      }

      public void Error<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Error, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Error<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Error, message, argument1, argument2, argument3 );
      }

      public void Fatal<T>( T value )
      {
         Log( LogLevel.Fatal, value );
      }

      public void Fatal<T>( IFormatProvider formatProvider, T value )
      {
         Log( LogLevel.Fatal, formatProvider, value );
      }

      public void Fatal( string message, Exception exception )
      {
         Log( LogLevel.Fatal, message, exception );
      }

      public void Fatal( Exception exception, string message, params object[] args )
      {
         Log( LogLevel.Fatal, message, exception, args );
      }

      public void Fatal( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Fatal, formatProvider, message, exception, args );
      }

      public void Fatal( IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( LogLevel.Fatal, formatProvider, message, args );
      }

      public void Fatal( string message )
      {
         Log( LogLevel.Fatal, message );
      }

      public void Fatal( string message, params object[] args )
      {
         Log( LogLevel.Fatal, message, args );
      }

      public void Fatal<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( LogLevel.Fatal, formatProvider, message, argument );
      }

      public void Fatal<TArgument>( string message, TArgument argument )
      {
         Log( LogLevel.Fatal, message, argument );
      }

      public void Fatal<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Fatal, formatProvider, message, argument1, argument2 );
      }

      public void Fatal<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( LogLevel.Fatal, message, argument1, argument2 );
      }

      public void Fatal<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Fatal, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Fatal<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( LogLevel.Fatal, message, argument1, argument2, argument3 );
      }
   }
}
