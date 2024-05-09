using LifeManage.src.Application.Filter;
using LifeManage.src.Application.StartUp;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile();

Log.Logger = new LoggerConfiguration()
	.ReadFrom.Configuration(builder.Configuration)
	.CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers(c =>
{
	c.Filters.Add(typeof(ExceptionFilter));
});

builder.Services.AddCors(option =>
	option.AddDefaultPolicy(policy =>
	{
		policy.AllowAnyOrigin()
			  .AllowAnyMethod()
			  .AllowAnyHeader();
	})
);

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddServices();
builder.Services.AddRepository(builder.Configuration);
builder.Services.AddAuth();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSerilogRequestLogging(options =>
{
	options.MessageTemplate = "Handled {RequestPath}";
	options.EnrichDiagnosticContext = (diagnosticContext, httpContext) =>
	{
		diagnosticContext.Set("RequestHost", httpContext.Request.Host.Value);
		diagnosticContext.Set("RequestScheme", httpContext.Request.Scheme);
		diagnosticContext.Set("UserID", httpContext.User.Identity?.Name);
	};
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
