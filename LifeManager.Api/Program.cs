using LifeManage.src.Application.Filter;
using LifeManage.src.Application.StartUp;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile();

builder.Services.AddControllers(c =>
{
	c.Filters.Add(typeof(ExceptionFilter));
});

// Add services to the container.
builder.Services.AddApplicationServices();
builder.Services.AddRepository(builder.Configuration);
builder.Services.AddAuth();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
}
app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
