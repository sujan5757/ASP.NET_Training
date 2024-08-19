1) Install pacckage
Microsoft.Extensions.Logging.Log4Net.AspNetCore

2)Program.cs
using Microsoft.Extensions.Logging;
builder.Logging.ClearProviders();
builder.Logging.AddLog4Net();

3)create a file in project root directory with the name "log4net.config" by choosing xml file template
Paste the following code

<log4net>
	<appender name="Console" type="log4net.Appender.ConsoleAppender">
		<layout type="log4net.Layout.PatternLayout">
			<!-- Pattern to output the caller's file name and line number -->
			<conversionPattern value="%date %5level %logger.%method [%property{eventId}] [%line] - MESSAGE: %message%newline %exception" />
		</layout>
	</appender>
	<appender name="RollingFile" type="log4net.Appender.RollingFileAppender">
		<file value="example.log" />
		<appendToFile value="true" />
		<maximumFileSize value="100KB" />
		<maxSizeRollBackups value="2" />
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date %5level %logger.%method [%property{eventId}] [%line] - MESSAGE: %message%newline %exception" />
		</layout>
	</appender>
	<appender name="TraceAppender" type="log4net.Appender.TraceAppender">
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date %5level %logger.%method [%property{eventId}] [%line] - MESSAGE: %message%newline %exception" />
		</layout>
	</appender>
	<appender name="ConsoleAppender" type="log4net.Appender.ManagedColoredConsoleAppender">
		<mapping>
			<level value="ERROR" />
			<foreColor value="Red" />
		</mapping>
		<mapping>
			<level value="WARN" />
			<foreColor value="Yellow" />
		</mapping>
		<mapping>
			<level value="INFO" />
			<foreColor value="White" />
		</mapping>
		<mapping>
			<level value="DEBUG" />
			<foreColor value="Green" />
		</mapping>
		<layout type="log4net.Layout.PatternLayout">
			<conversionPattern value="%date %5level %logger.%method [%property{eventId}] [%line] - MESSAGE: %message%newline %exception" />
		</layout>
	</appender>
	<root>
		<level value="TRACE" />
		<appender-ref ref="RollingFile" />
		<appender-ref ref="TraceAppender" />
		<appender-ref ref="ConsoleAppender" />
	</root>
</log4net>

4)To generate exception and log it in WeatherForecastController
Add the following code in Get method
try
        {
            int a = 10;
            int b = 0;
            int res = a / b;
        }
        catch(DivideByZeroException ex)
        {
            _logger.Log(LogLevel.Error, ex.Message);
        }

5)Run the app

6)Select solution from solution explorer and show all files
bin->debug->.net 7-> example.log for log  information
