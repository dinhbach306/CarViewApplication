
using Application2;
using Application2.IService;
using Application2.Service;
using Infrastructures2;
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