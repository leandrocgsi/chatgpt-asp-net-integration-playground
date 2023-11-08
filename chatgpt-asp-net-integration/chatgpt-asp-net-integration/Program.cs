using ChatGPT.ASP.NET.Integration.Extensions;

var builder = WebApplication.CreateBuilder(args);
builder.AddSerilog(builder.Configuration, "ChatGPT ASP.NET 8 Integration");
builder.AddChatGpt(builder.Configuration);

builder.Services.AddRouting(options => options.LowercaseUrls = true);
builder.Services.AddControllers();

builder.Services.AddSwagger(builder.Configuration);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseRouting();

app.UseSwaggerDoc();

app.MapControllers();

app.Run();