namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using AutoFac.Extras.NLog.NetCore20;

   public class SampleClassWithConstructorDependency: ISampleClass
   {
      private readonly ILogger logger;

      public SampleClassWithConstructorDependency( ILogger logger )
      {
         this.logger = logger;
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
