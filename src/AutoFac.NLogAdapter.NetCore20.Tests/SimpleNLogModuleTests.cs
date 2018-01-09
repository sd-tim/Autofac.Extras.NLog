namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using Autofac;
   using NetCore20;
   using NUnit.Framework;

   [ TestFixture ]
   public class SimpleNLogModuleTests
   {
      private IContainer container;

      public SimpleNLogModuleTests()
      {
         BuildSampleContainer();
      }

      private void BuildSampleContainer()
      {
         ContainerBuilder containerBuilder = new ContainerBuilder();

         containerBuilder.RegisterModule<SimpleNLogModule>();

         containerBuilder
            .RegisterType<SampleClassWithConstructorDependency>()
            .Named<ISampleClass>( "constructor" );

         containerBuilder
            .RegisterType<SampleClassWithPropertyDependency>()
            .Named<ISampleClass>( "property" )
            .PropertiesAutowired();

         containerBuilder
            .RegisterType<SampleClassToResolveLoggerFromServiceLocator>()
            .Named<ISampleClass>( "serviceLocator" );

         container = containerBuilder.Build();
      }

      [ Test ]
      public void Inject_logger_to_constructor_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "constructor" );
         Assert.NotNull( sampleClass.GetLogger() );
      }

      [ Test ]
      public void Iject_logger_to_property_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "property" );
         Assert.NotNull( sampleClass.GetLogger() );
      }

      [ Test ]
      public void Resolve_logger_from_lifetime_scope_test()
      {
         ISampleClass sampleClass = container.ResolveNamed<ISampleClass>( "serviceLocator" );
         Assert.NotNull( sampleClass.GetLogger() );
      }
   }
}
