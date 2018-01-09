namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using Autofac;
   using NetCore20;
   using NUnit.Framework;

   [ TestFixture ]
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

      [ Test ]
      public void Inject_logger_into_constructor_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "constructor" );

         Assert.NotNull( sampleClass.GetLogger() );
      }

      [ Test ]
      public void Inject_logger_into_property_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "property" );

         Assert.NotNull( sampleClass.GetLogger() );
      }
   }
}
