namespace AutoFac.NLogAdapter.NetCore20.Tests
{
   using System;
   using System.Globalization;
   using NLog;
   using NUnit.Framework;

   [ TestFixture ]
   public class When_using_the_callsite_in_a_layout: Test_fixture
   {
      [ OneTimeSetUp ]
      public void Set_up_test_fixture()
      {
         DeleteLogFile();
      }

      [ SetUp ]
      public void Set_up_test_context()
      {
         TestCode = $"{Guid.NewGuid():N}";
      }

      [ Test ]
      public void Should_specify_the_calling_type()
      {
         Logger.Log( LogLevel.Error, TestCode );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_and_generic_value()
      {
         Logger.Log<object>( LogLevel.Trace, new { message = TestCode } );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_format_provider_and_generic_value()
      {
         Logger.Log<object>( LogLevel.Debug, CultureInfo.CurrentCulture, new { message = TestCode } );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_message_and_exception()
      {
         var exception = new Exception( TestCode );
         Logger.Log( LogLevel.Fatal, exception, TestCode );

         VerifyLogMessage( TestCode );
         VerifyException( exception );
      }

      [ Test ]
      public void Should_work_for_level_format_provider_message_and_arguments()
      {
         Logger.Log( LogLevel.Debug, CultureInfo.InstalledUICulture, "Testcode: {0}", new object[] { TestCode } );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_message_and_args()
      {
         Logger.Log( LogLevel.Error, "Testcode: {0}", new object[] { TestCode } );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_format_provider_message_and_generic_argument()
      {
         Logger.Log<string>( LogLevel.Info, CultureInfo.InstalledUICulture, "Testcode: {0}", TestCode );

         VerifyLogMessage( TestCode );
      }

      [ Test ]
      public void Should_work_for_level_format_provider_message_and_two_generic_arguments()
      {
         var exception = new Exception( "Exception!" );
         Logger.Log<string, Exception>( LogLevel.Warn, CultureInfo.InstalledUICulture, "Message: {0}, Exception: {1}", TestCode, exception );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";

         Logger.Log<Exception, string>( LogLevel.Fatal, CultureInfo.InstalledUICulture, "Exception: {0}, Code: {1}", exception, TestCode );

         VerifyLogMessage( TestCode );
         VerifyException( exception );
      }

      [ Test ]
      public void Should_work_for_level_message_and_two_generic_arguments()
      {
         var exception = new Exception( "Nope" );
         Logger.Log<string, Exception>( LogLevel.Debug, "Code: {0}, Exception: {1}", TestCode, exception );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";

         Logger.Log<Exception, string>( LogLevel.Error, "Exception: {0}, Code: {1}", exception, TestCode );

         VerifyLogMessage( TestCode );
         VerifyException( exception );
      }

      [ Test ]
      public void Should_work_for_level_format_provider_message_and_three_generic_arguments()
      {
         var exception = new Exception( "Nu-uh!" );
         Logger.Log<int, string, Exception>( LogLevel.Fatal, CultureInfo.InstalledUICulture, "Number: {0}, Code: {1}, Exception:{2}", 12, TestCode, exception );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";
         Logger.Log<Exception, int, string>( LogLevel.Error, CultureInfo.InstalledUICulture, "Exception: {0}, Number: {1}, Code: {2}", exception, 12, TestCode );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";

         Logger.Log<string, Exception, int>( LogLevel.Debug, CultureInfo.InstalledUICulture, "Code: {0}, Exception: {1}, Number: {2}", TestCode, exception, 12 );

         VerifyLogMessage( TestCode );
         VerifyException( exception );
      }

      [ Test ]
      public void Should_work_for_level_message_and_three_generic_arguments()
      {
         var exception = new Exception( "Not today" );
         Logger.Log<int, string, Exception>( LogLevel.Error, "Number: {0}, Code: {1}, Exception: {2}", 12, TestCode, exception );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";
         Logger.Log<Exception, int, string>( LogLevel.Info, "Exception: {0}, Number: {1}, Code: {2}", exception, 12, TestCode );

         VerifyLogMessage( TestCode );
         VerifyException( exception );

         TestCode = $"{Guid.NewGuid():N}";
         Logger.Log<string, Exception, int>( LogLevel.Debug, "Code: {0}, Exception: {1}, Number: {2}", TestCode, exception, 12 );

         VerifyLogMessage( TestCode );
         VerifyException( exception );
      }
   }
}
