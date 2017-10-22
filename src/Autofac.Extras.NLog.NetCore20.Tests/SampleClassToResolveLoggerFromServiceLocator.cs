namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using Autofac;

   public class SampleClassToResolveLoggerFromServiceLocator: ISampleClass
   {
      private readonly ILogger logger;

      public SampleClassToResolveLoggerFromServiceLocator( ILifetimeScope serviceLocator )
      {
         logger = serviceLocator.Resolve<ILogger>();
      }

      public void SampleMessage( string message )
      {
         logger.Debug( message );
      }

      public ILogger GetLogger()
      {
         return logger;
      }
   }
}
