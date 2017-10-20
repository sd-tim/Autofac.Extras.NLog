namespace AutoFac.Extras.NLog.NetCore20
{
   using Autofac;
   using global::NLog;

   public class SimpleNLogModule: Module
   {
      protected override void Load( ContainerBuilder builder )
      {
         builder.Register( context => new LoggerAdapter( LogManager.GetCurrentClassLogger() ) )
                .As<ILogger>()
                .SingleInstance();
      }
   }
}
