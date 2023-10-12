using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Test3.Data;
using Test3.Models;
using Test3.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ModelContext>(options => options.UseOracle(builder.Configuration.GetConnectionString("OracleDBConnection")));
builder.Services.AddTransient<IEmpRepository, EmpRepository>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
