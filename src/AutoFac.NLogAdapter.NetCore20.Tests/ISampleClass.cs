namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   public interface ISampleClass
   {
      void SampleMessage( string message );
      NLog.ILogger GetLogger();
   }
}
