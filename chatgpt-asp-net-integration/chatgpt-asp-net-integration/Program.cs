using ChatGPT.ASP.NET.Integration.Extensions;
using ChatGPT.ASP.NET.Integration.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog(builder.Configuration, "ChatGPT ASP.NET 8 Integration");
builder.AddChatGpt(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseRouting();

app.UseSwaggerDoc();

app.MapControllers();

app.Run();