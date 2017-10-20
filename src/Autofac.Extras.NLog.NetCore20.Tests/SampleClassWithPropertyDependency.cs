namespace Autofac.Extras.NLog.NetCore20.Tests
{
   using AutoFac.Extras.NLog.NetCore20;

   public class SampleClassWithPropertyDependency: ISampleClass
   {
      public ILogger Logger { get; set; }

      public void SampleMessage( string message )
      {
         Logger.Debug( message );
      }

      public ILogger GetLogger()
      {
         return Logger;
      }
   }
}
