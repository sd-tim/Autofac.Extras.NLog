namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using System;
   using System.Linq;
   using System.Text.RegularExpressions;
   using Autofac;
   using FluentAssertions;
   using NLog;
   using NLog.Config;
   using NLog.Targets;
   using Xunit;
   using Xunit.Abstractions;

   public class When_using_the_callsite_in_a_layout
   {
      private readonly ITestOutputHelper output;
      private readonly IContainer container;
      private readonly MemoryTarget nlogMemoryTarget;

      public When_using_the_callsite_in_a_layout( ITestOutputHelper output )
      {
         this.output = output;

         nlogMemoryTarget = new MemoryTarget { Layout = "${longdate} ${uppercase:${level}} ${callsite} ${message}${onexception:${newline}${exception}${newline}}" };
         SimpleConfigurator.ConfigureForTargetLogging( nlogMemoryTarget, LogLevel.Trace );

         var builder = new ContainerBuilder();
         builder.RegisterModule<NLogModule>();
         builder.RegisterType<SampleClassWithPropertyDependency>()
                .Named<ISampleClass>( "property" )
                .PropertiesAutowired();

         container = builder.Build();
      }

      [ Fact ]
      public void Should_specify_the_correct_calling_type_and_method_names()
      {
         var logger = container.ResolveNamed<ISampleClass>( "property" ).GetLogger();
         logger.Should().NotBeNull();

         string testId = $"{Guid.NewGuid():N}";
         logger.Error( testId );

         var lastLineOfLogs = nlogMemoryTarget.Logs.Last( x => x.EndsWith( testId ) );

         var logLinePattern = new Regex( @"^(?<date>\d{4}-\d{2}-\d{2})\s(?<time>[\d:.]{13})\s(?<level>INFO|ERROR|WARNING)\s(?<callsite>[A-za-z0-9.]+)\s(?<msg>.*)$" );

         Match match = logLinePattern.Match( lastLineOfLogs );
         match.Success.Should().BeTrue( because: "layout should match the regex" );

         output.WriteLine( $"Callsite contains: {match.Groups[ "callsite" ].Value}" );

         match.Groups[ "callsite" ].Value.Should().Be( $"{GetType().FullName}.{nameof(Should_specify_the_correct_calling_type_and_method_names)}",
                                                       because: "should use the actual calling method context." );
      }
   }
}
