using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using poc.src.app.Api.Controllers;
using poc.src.app.Application.Interfaces;
using poc.src.app.Application.UseCases;
using poc.src.app.Domain.Repositories;
using poc.src.app.Infra.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext with SQL Server configuration
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    // Use SQL Server with the connection string from appsettings.json
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});


builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<ICreateVehiclesUseCase, CreateVehiclesUseCase>();
builder.Services.AddScoped<IDeleteVehiclesUseCase, DeleteVehiclesUseCase>();
builder.Services.AddScoped<IGetAllVehiclesUseCase, GetAllVehiclesUseCase>();
builder.Services.AddScoped<IGetByIdVehiclesUseCase, GetByIdVehiclesUseCase>();
builder.Services.AddScoped<IUptadeVehiclesUseCase, UptadeVehiclesUseCase>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.MapControllers(); 
app.Run();