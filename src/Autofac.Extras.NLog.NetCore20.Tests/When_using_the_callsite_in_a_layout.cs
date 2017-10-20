namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using System;
   using System.Collections.Generic;
   using System.IO;
   using System.Linq;
   using System.Text.RegularExpressions;
   using AutoFac.Extras.NLog.NetCore20;
   using FluentAssertions;
   using global::NLog;
   using Xunit;
   using Xunit.Abstractions;

   public class When_using_the_callsite_in_a_layout
   {
      private readonly ITestOutputHelper output;
      private readonly IContainer container;

      public When_using_the_callsite_in_a_layout( ITestOutputHelper output )
      {
         this.output = output;
         var builder = new ContainerBuilder();
         builder.RegisterModule<NLogModule>();
         builder.RegisterType<SampleClassWithPropertyDependency>()
                .Named<ISampleClass>( "property" )
                .PropertiesAutowired();

         container = builder.Build();
      }

      [ Fact ]
      public void Should_specify_the_calling_type()
      {
         var logger = container.ResolveNamed<ISampleClass>( "property" ).GetLogger();
         logger.Should().NotBeNull();

         logger.Log( LogLevel.Error, "Something happened!" );

         var directory = AppDomain.CurrentDomain.BaseDirectory;
         var logPath = Path.Combine( directory, "logs", $"{DateTime.Now:yyyy-MM-dd}.log" );

         File.Exists( logPath ).Should().BeTrue( because: "log file should exist" );

         IEnumerable<string> logs = File.ReadLines( logPath );

         var logLinePattern = new Regex( @"^(?<date>\d{4}-\d{2}-\d{2})\s(?<time>[\d:.]{13})\s(?<level>INFO|ERROR|WARNING)\s(?<callsite>[A-za-z0-9.]+)\s(?<msg>.*)$" );

         var lastLineOfLogs = logs.Last();
         Match match = logLinePattern.Match( lastLineOfLogs );
         match.Success.Should().BeTrue( because: "Should match the regex" );

         match.Groups[ "callsite" ].Value.Should().NotBe( "AutoFac.Extras.NLog.NetCore20.LoggerAdapter.Log", because: "should not contain the name of the logging module" );
         output.WriteLine( match.Groups[ "callsite" ].Value );
      }
   }
}
