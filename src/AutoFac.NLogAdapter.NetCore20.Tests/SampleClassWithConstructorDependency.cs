namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   public class SampleClassWithConstructorDependency: ISampleClass
   {
      private readonly NLog.ILogger logger;

      public SampleClassWithConstructorDependency( NLog.ILogger logger )
      {
         this.logger = logger;
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
