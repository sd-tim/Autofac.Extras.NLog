namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using Autofac;

   public class SampleClassToResolveLoggerFromServiceLocator: ISampleClass
   {
      private readonly NLog.ILogger logger;

      public SampleClassToResolveLoggerFromServiceLocator( ILifetimeScope serviceLocator )
      {
         logger = serviceLocator.Resolve<NLog.ILogger>();
      }

      public void SampleMessage( string message )
      {
         logger.Debug( message );
      }

      public NLog.ILogger GetLogger()
      {
         return logger;
      }
   }
}
