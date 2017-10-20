namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using AutoFac.Extras.NLog.NetCore20;

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
