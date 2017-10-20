namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using AutoFac.Extras.NLog.NetCore20;
   using Xunit;

   public class NLogModuleTests
   {
      private IContainer container;

      public NLogModuleTests()
      {
         BuildSampleContainer();
      }

      private void BuildSampleContainer()
      {
         ContainerBuilder containerBuilder = new ContainerBuilder();
         containerBuilder.RegisterModule<NLogModule>();
         containerBuilder.RegisterType<SampleClassWithConstructorDependency>().Named<ISampleClass>( "constructor" );
         containerBuilder.RegisterType<SampleClassWithPropertyDependency>().Named<ISampleClass>( "property" );
         container = containerBuilder.Build();
      }

      [ Fact ]
      public void Inject_logger_into_constructor_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "constructor" );

         Assert.NotNull( sampleClass.GetLogger() );
      }

      [ Fact ]
      public void Inject_logger_into_property_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "property" );

         Assert.NotNull( sampleClass.GetLogger() );
      }
   }
}
