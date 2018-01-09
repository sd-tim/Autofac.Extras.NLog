namespace AutoFac.NLogAdapter.NetCore20
{
   using System;
   using NLog;

   /// <summary>
   ///    Implementation of ILogger, deriving from NLog.Logger
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
         Log( GetType(), logEvent );
      }

      public void Log( Type wrapperType, LogEventInfo logEvent )
      {
         logger.Log( wrapperType, logEvent );
      }

      public void Log<T>( LogLevel level, T value )
      {
         Log( new LogEventInfo( level, Name, value.ToString() ) { Exception = value as Exception } );
      }

      public void Log<T>( LogLevel level, IFormatProvider formatProvider, T value )
      {
         Log( new LogEventInfo( level, Name, formatProvider, value.ToString(), Array.Empty<object>() ) { Exception = value as Exception } );
      }

      public void LogException( LogLevel level, string message, Exception exception )
      {
         Log( new LogEventInfo( level, Name, null, message, Array.Empty<object>(), exception ) );
      }

      public void Log( LogLevel level, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( level, Name, formatProvider, message, args ) );
      }

      public void Log( LogLevel level, string message )
      {
         Log( new LogEventInfo( level, Name, message ) );
      }

      public void Log( LogLevel level, string message, params object[] args )
      {
         Log( new LogEventInfo( level, Name, null, message, args ) );
      }

      public void Log<TArgument>( LogLevel level, IFormatProvider formatProvider, string message, TArgument argument )
      {
         Log( new LogEventInfo( level, Name, formatProvider, message, new object[] { argument } )
              {
                 Exception = argument as Exception
              } );
      }

      public void Log<TArgument>( LogLevel level, string message, TArgument argument )
      {
         Log( new LogEventInfo( level, Name, null, message, new object[] { argument } )
              {
                 Exception = argument as Exception
              } );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( new LogEventInfo( level, Name, formatProvider, message, new object[] { argument1, argument2 } )
              {
                 Exception = argument1 as Exception ?? argument2 as Exception
              } );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         Log( new LogEventInfo( level, Name, null, message, new object[] { argument1, argument2 } )
              {
                 Exception = argument1 as Exception ?? argument2 as Exception
              } );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( new LogEventInfo( level, Name, formatProvider, message, new object[] { argument1, argument2, argument3 } )
              {
                 Exception = argument1 as Exception ?? argument2 as Exception ?? argument3 as Exception
              } );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         Log( new LogEventInfo( level, Name, null, message, new object[] { argument1, argument2, argument3 } )
              {
                 Exception = argument1 as Exception ?? argument2 as Exception ?? argument3 as Exception
              } );
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
         LogException( LogLevel.Trace, message, exception );
      }

      public void Trace( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Trace, Name, null, message, args, exception ) );
      }

      public void Trace( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Trace, Name, formatProvider, message, args, exception ) );
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
         LogException( LogLevel.Debug, message, exception );
      }

      public void Debug( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Debug, Name, null, message, args, exception ) );
      }

      public void Debug( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Debug, Name, formatProvider, message, args, exception ) );
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
         LogException( LogLevel.Info, message, exception );
      }

      public void Info( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Info, Name, null, message, args, exception ) );
      }

      public void Info( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Info, Name, formatProvider, message, args, exception ) );
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
         LogException( LogLevel.Warn, message, exception );
      }

      public void Warn( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Warn, Name, null, message, args, exception ) );
      }

      public void Warn( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Warn, Name, formatProvider, message, args, exception ) );
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
         LogException( LogLevel.Error, message, exception );
      }

      public void Error( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Error, Name, null, message, args, exception ) );
      }

      public void Error( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Error, Name, formatProvider, message, args, exception ) );
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
         LogException( LogLevel.Fatal, message, exception );
      }

      public void Fatal( Exception exception, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Fatal, Name, null, message, args, exception ) );
      }

      public void Fatal( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         Log( new LogEventInfo( LogLevel.Fatal, Name, formatProvider, message, args, exception ) );
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