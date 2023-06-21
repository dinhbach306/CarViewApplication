
using Application;
using Application.IService;
using Application.Service;
using Infrastructures;
using UniCar;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddWebApiService();
builder.Services.AddInfrastructures(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();