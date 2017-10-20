namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using AutoFac.Extras.NLog.NetCore20;

   public interface ISampleClass
   {
      void SampleMessage( string message );
      ILogger GetLogger();
   }
}
