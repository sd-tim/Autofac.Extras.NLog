namespace AutoFac.Extras.NLog.NetCore20
{
   using System;
   using global::NLog;

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
         logger.Log( typeof( LoggerAdapter ), logEvent );
      }

      public void Log( Type wrapperType, LogEventInfo logEvent )
      {
         logger.Log( wrapperType, logEvent );
      }

      public void Log<T>( LogLevel level, T value )
      {
         logger.Log( level, value );
      }

      public void Log<T>( LogLevel level, IFormatProvider formatProvider, T value )
      {
         logger.Log( level, formatProvider, value );
      }

      public void LogException( LogLevel level, string message, Exception exception )
      {
         logger.Log( level, exception, message );
      }

      public void Log( LogLevel level, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Log( level, formatProvider, message, args );
      }

      public void Log( LogLevel level, string message )
      {
         logger.Log( level, message );
      }

      public void Log( LogLevel level, string message, params object[] args )
      {
         logger.Log( level, message, args );
      }

      public void Log<TArgument>( LogLevel level, IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Log( level, formatProvider, message, argument );
      }

      public void Log<TArgument>( LogLevel level, string message, TArgument argument )
      {
         logger.Log( level, message, argument );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Log( level, formatProvider, message, argument1, argument2 );
      }

      public void Log<TArgument1, TArgument2>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Log( level, message, argument1, argument2 );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Log( level, formatProvider, message, argument1, argument2, argument3 );
      }

      public void Log<TArgument1, TArgument2, TArgument3>( LogLevel level, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Log( level, message, argument1, argument2, argument3 );
      }

      public void Trace<T>( T value )
      {
         logger.Trace( value );
      }

      public void Trace<T>( IFormatProvider formatProvider, T value )
      {
         logger.Trace( formatProvider, value );
      }

      public void Trace( string message, Exception exception )
      {
         logger.Trace( exception, message );
      }

      public void Trace( Exception exception, string message, params object[] args )
      {
         logger.Trace( exception, message );
      }

      public void Trace( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Trace( exception, formatProvider, message, args );
      }

      public void Trace( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Trace( formatProvider, message, args );
      }

      public void Trace( string message )
      {
         logger.Trace( message );
      }

      public void Trace( string message, params object[] args )
      {
         logger.Trace( message, args );
      }

      public void Trace<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Trace( formatProvider, message, argument );
      }

      public void Trace<TArgument>( string message, TArgument argument )
      {
         logger.Trace( message, argument );
      }

      public void Trace<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Trace( formatProvider, message, argument1, argument2 );
      }

      public void Trace<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Trace( message, argument1, argument2 );
      }

      public void Trace<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Trace( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Trace<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Trace( message, argument1, argument2, argument3 );
      }

      public void Debug<T>( T value )
      {
         logger.Debug( value );
      }

      public void Debug<T>( IFormatProvider formatProvider, T value )
      {
         logger.Debug( formatProvider, value );
      }

      public void Debug( string message, Exception exception )
      {
         logger.Debug( exception, message );
      }

      public void Debug( Exception exception, string message, params object[] args )
      {
         logger.Debug( exception, message, args );
      }

      public void Debug( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Debug( exception, formatProvider, message, args );
      }

      public void Debug( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Debug( formatProvider, message, args );
      }

      public void Debug( string message )
      {
         logger.Debug( message );
      }

      public void Debug( string message, params object[] args )
      {
         logger.Debug( message, args );
      }

      public void Debug<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Debug( formatProvider, message, argument );
      }

      public void Debug<TArgument>( string message, TArgument argument )
      {
         logger.Debug( message, argument );
      }

      public void Debug<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Debug( formatProvider, message, argument1, argument2 );
      }

      public void Debug<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Debug( message, argument1, argument2 );
      }

      public void Debug<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Debug( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Debug<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Debug( message, argument1, argument2, argument3 );
      }

      public void Info<T>( T value )
      {
         logger.Info( value );
      }

      public void Info<T>( IFormatProvider formatProvider, T value )
      {
         logger.Info( formatProvider, value );
      }

      public void Info( string message, Exception exception )
      {
         logger.Info( exception, message );
      }

      public void Info( Exception exception, string message, params object[] args )
      {
         logger.Info( exception, message, args );
      }

      public void Info( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Info( exception, formatProvider, message, args );
      }

      public void Info( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Info( formatProvider, message, args );
      }

      public void Info( string message )
      {
         logger.Info( message );
      }

      public void Info( string message, params object[] args )
      {
         logger.Info( message, args );
      }

      public void Info<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Info( formatProvider, message, argument );
      }

      public void Info<TArgument>( string message, TArgument argument )
      {
         logger.Info( message, argument );
      }

      public void Info<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Info( formatProvider, message, argument1, argument2 );
      }

      public void Info<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Info( message, argument1, argument2 );
      }

      public void Info<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Info( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Info<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Info( message, argument1, argument2, argument3 );
      }

      public void Warn<T>( T value )
      {
         logger.Warn( value );
      }

      public void Warn<T>( IFormatProvider formatProvider, T value )
      {
         logger.Warn( formatProvider, value );
      }

      public void Warn( string message, Exception exception )
      {
         logger.Warn( exception, message );
      }

      public void Warn( Exception exception, string message, params object[] args )
      {
         logger.Warn( exception, message, args );
      }

      public void Warn( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Warn( exception, formatProvider, message, args );
      }

      public void Warn( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Warn( formatProvider, message, args );
      }

      public void Warn( string message )
      {
         logger.Warn( message );
      }

      public void Warn( string message, params object[] args )
      {
         logger.Warn( message, args );
      }

      public void Warn<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Warn( formatProvider, message, argument );
      }

      public void Warn<TArgument>( string message, TArgument argument )
      {
         logger.Warn( message, argument );
      }

      public void Warn<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Warn( formatProvider, message, argument1, argument2 );
      }

      public void Warn<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Warn( message, argument1, argument2 );
      }

      public void Warn<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Warn( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Warn<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Warn( message, argument1, argument2, argument3 );
      }

      public void Error<T>( T value )
      {
         logger.Error( value );
      }

      public void Error<T>( IFormatProvider formatProvider, T value )
      {
         logger.Error( formatProvider, value );
      }

      public void Error( string message, Exception exception )
      {
         logger.Error( exception, message );
      }

      public void Error( Exception exception, string message, params object[] args )
      {
         logger.Error( exception, message, args );
      }

      public void Error( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Error( exception, formatProvider, message, args );
      }

      public void Error( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Error( formatProvider, message, args );
      }

      public void Error( string message )
      {
         logger.Error( message );
      }

      public void Error( string message, params object[] args )
      {
         logger.Error( message, args );
      }

      public void Error<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Error( formatProvider, message, argument );
      }

      public void Error<TArgument>( string message, TArgument argument )
      {
         logger.Error( message, argument );
      }

      public void Error<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Error( formatProvider, message, argument1, argument2 );
      }

      public void Error<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Error( message, argument1, argument2 );
      }

      public void Error<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Error( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Error<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Error( message, argument1, argument2, argument3 );
      }

      public void Fatal<T>( T value )
      {
         logger.Fatal( value );
      }

      public void Fatal<T>( IFormatProvider formatProvider, T value )
      {
         logger.Fatal( formatProvider, value );
      }

      public void Fatal( string message, Exception exception )
      {
         logger.Fatal( exception, message );
      }

      public void Fatal( Exception exception, string message, params object[] args )
      {
         logger.Fatal( exception, message, args );
      }

      public void Fatal( Exception exception, IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Fatal( exception, formatProvider, message, args );
      }

      public void Fatal( IFormatProvider formatProvider, string message, params object[] args )
      {
         logger.Fatal( formatProvider, message, args );
      }

      public void Fatal( string message )
      {
         logger.Fatal( message );
      }

      public void Fatal( string message, params object[] args )
      {
         logger.Fatal( message, args );
      }

      public void Fatal<TArgument>( IFormatProvider formatProvider, string message, TArgument argument )
      {
         logger.Fatal( formatProvider, message, argument );
      }

      public void Fatal<TArgument>( string message, TArgument argument )
      {
         logger.Fatal( message, argument );
      }

      public void Fatal<TArgument1, TArgument2>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Fatal( formatProvider, message, argument1, argument2 );
      }

      public void Fatal<TArgument1, TArgument2>( string message, TArgument1 argument1, TArgument2 argument2 )
      {
         logger.Fatal( message, argument1, argument2 );
      }

      public void Fatal<TArgument1, TArgument2, TArgument3>( IFormatProvider formatProvider, string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Fatal( formatProvider, message, argument1, argument2, argument3 );
      }

      public void Fatal<TArgument1, TArgument2, TArgument3>( string message, TArgument1 argument1, TArgument2 argument2, TArgument3 argument3 )
      {
         logger.Fatal( message, argument1, argument2, argument3 );
      }
   }
}
