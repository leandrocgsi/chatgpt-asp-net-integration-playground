using Microsoft.OpenApi.Models;

namespace ChatGPT.ASP.NET.Integration.Extensions;

public static class SwaggerExtensions
{
	public static void AddSwagger(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddSwaggerGen(c =>
		{
			c.SwaggerDoc("v1", new OpenApiInfo
			{
				Title = "ChatGPT ASP.NET 8 Integration",
				Version = "v1"
			});
			c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
		});
	}

	public static void UseSwaggerDoc(this IApplicationBuilder app)
	{
		app.UseSwagger();
		app.UseSwaggerUI(c =>
		{
			c.SwaggerEndpoint("/swagger/v1/swagger.json", "ChatGPT ASP.NET 8 Integration");
			c.RoutePrefix = "swagger";
		});
	}
}