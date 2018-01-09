namespace AutoFac.NLogAdapter.NetCore20.Tests
{
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
