
using Application2;
using Application2.IService;
using Application2.Service;
using Infrastructures2;
using Microsoft.Extensions.FileProviders;
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

app.UseFileServer(new FileServerOptions
{
    //Get staticFile in WebUI project
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "StaticFile")),
    RequestPath = "/StaticFile",
    EnableDefaultFiles = true
});
app.UseStaticFiles();

app.Run();