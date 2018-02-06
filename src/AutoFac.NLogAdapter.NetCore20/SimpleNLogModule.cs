﻿namespace AutoFac.NLogAdapter.NetCore20
{
   using Autofac;
   using NLog;

   public class SimpleNLogModule: Module
   {
      protected override void Load( ContainerBuilder builder )
      {
         builder.Register( context => LogManager.GetCurrentClassLogger() )
                .As<ILogger>()
                .SingleInstance();
      }
   }
}
