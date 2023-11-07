﻿using Serilog;
using Serilog.Configuration;

namespace ChatGPT.ASP.NET.Integration.Extensions;

public static class SerilogExtensions
{
	public static WebApplicationBuilder AddSerilog(this WebApplicationBuilder builder, IConfiguration configuration, string applicationName)
	{
		Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();

		builder.Logging.ClearProviders();
		builder.Host.UseSerilog(Log.Logger, true);

		return builder;
	}
}