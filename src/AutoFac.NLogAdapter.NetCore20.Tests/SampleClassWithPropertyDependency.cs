namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   public class SampleClassWithPropertyDependency: ISampleClass
   {
      public NLog.ILogger Logger { get; set; }

      public void SampleMessage( string message )
      {
         Logger.Debug( message );
      }

      public NLog.ILogger GetLogger()
      {
         return Logger;
      }
   }
}
