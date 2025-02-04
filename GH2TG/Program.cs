using GH2TG.Interfaces;
using GH2TG.Models;
using GH2TG.Services;
using Microsoft.Extensions.Options;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers()
	 .AddJsonOptions(options =>
	 {
		 options.JsonSerializerOptions.PropertyNamingPolicy = System.Text.Json.JsonNamingPolicy.CamelCase;
	 });
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Configuration.AddJsonFile("config.json");

builder.Services.Configure<TelegramCredentials>(builder.Configuration.GetSection("TelegramCredentials"));
builder.Services.AddSingleton<IValidateOptions<TelegramCredentials>, TelegramCredentialsValidator>();
builder.Services.AddSingleton(sp => sp.GetRequiredService<IOptions<TelegramCredentials>>().Value);
builder.Services.AddHttpClient<ITelegramService, TelegramService>();

builder.Services.AddTransient<ITelegramService, TelegramService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseExceptionHandler(errorApp =>
{
	errorApp.Run(async context =>
	{
		context.Response.StatusCode = 400;
		await context.Response.WriteAsync("{\"success\": false, \"message\": \"Invalid JSON format\"}");
	});
});

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
