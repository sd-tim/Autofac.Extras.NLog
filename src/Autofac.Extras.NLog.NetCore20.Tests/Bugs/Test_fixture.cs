namespace Autofac.Extras.NLog.NetCore20.Tests.Bugs
{
   using System;
   using System.Collections.Generic;
   using System.Diagnostics;
   using System.IO;
   using System.Linq;
   using System.Text.RegularExpressions;
   using AutoFac.Extras.NLog.NetCore20;
   using FluentAssertions;
   using NUnit.Framework;

   public abstract class Test_fixture
   {
      public IContainer Container { get; set; }

      public string TestCode { get; set; }

      [ SetUp ]
      protected void Set_up_test()
      {
         var builder = new ContainerBuilder();
         builder.RegisterModule<NLogModule>();
         builder.RegisterType<SampleClassWithPropertyDependency>()
                .Named<ISampleClass>( "property" )
                .PropertiesAutowired();

         Container = builder.Build();

         TestCode = Guid.NewGuid().ToString( "N" );
      }

      [ TearDown ]
      public void Tear_down_test()
      {
         Console.WriteLine( File.ReadAllText( LogPath ) );
         DeleteLogFile();
      }

      public ILogger Logger
      {
         get
         {
            var logger = Container.ResolveNamed<ISampleClass>( "property" ).GetLogger();
            logger.Should().NotBeNull( because: "logger should resolve from the container" );
            return logger;
         }
      }

      protected void DeleteLogFile()
      {
         var directory = AppDomain.CurrentDomain.BaseDirectory;
         var logPath = Path.Combine( directory, "logs", $"{DateTime.Now:yyyy-MM-dd}.log" );
         if( File.Exists( logPath ) )
            File.Delete( logPath );
      }

      private static string LogPath
      {
         get
         {
            var directory = AppDomain.CurrentDomain.BaseDirectory;
            return Path.Combine( directory, "logs", $"{DateTime.Now:yyyy-MM-dd}.log" );
         }
      }

      public void VerifyLogMessage( string testCode )
      {
         var callingMethod = new StackTrace().GetFrame( 1 ).GetMethod();
         var declaringTypeName = callingMethod.DeclaringType.FullName;
         var fullyQualifiedMemberName = $"{declaringTypeName}.{callingMethod.Name}";

         File.Exists( LogPath ).Should().BeTrue( because: "log file should exist" );

         IEnumerable<string> logs = File.ReadLines( LogPath );
         Console.WriteLine( string.Join( Environment.NewLine, logs ) );

         var logLinePattern = new Regex( @"^(?<date>\d{4}-\d{2}-\d{2})\s(?<time>[\d:.]{13})\s(?<level>WARN|TRACE|DEBUG|INFO|ERROR|FATAL|WARNING)\s(?<callsite>[A-za-z0-9.]+)\s(?<msg>.*)$" );

         var lastLineOfLogs = logs.LastOrDefault( x => x.Contains( testCode ) && logLinePattern.IsMatch( x ) );
         lastLineOfLogs.Should().NotBeNullOrWhiteSpace( because: "should be an entry from the logs" );

         Match match = logLinePattern.Match( lastLineOfLogs );
         match.Success.Should().BeTrue( because: "should match the regex" );

         Console.WriteLine( $"Callsite: {match.Groups[ "callsite" ]}" );
         match.Groups[ "callsite" ].Value.Should().NotBe( "AutoFac.Extras.NLog.NetCore20.LoggerAdapter.Log", because: "should not contain the name of the logging module" );
         match.Groups[ "callsite" ].Value.Should().Contain( fullyQualifiedMemberName, because: "should include the fully qualified method name of caller" );
      }

      public void VerifyException( Exception exception )
      {
         Console.WriteLine($"Exception: {exception}");

         File.ReadAllText( LogPath ).Contains( exception.ToString() )
             .Should().BeTrue( because: "exception should be included in log message" );
      }
   }
}
