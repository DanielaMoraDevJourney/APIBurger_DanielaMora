using APIBurger_DanielaMora.Controllers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using APIBurger_DanielaMora.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<APIBurger_DanielaMoraContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("APIBurger_DanielaMoraContext") ?? throw new InvalidOperationException("Connection string 'APIBurger_DanielaMoraContext' not found.")));

// Add services to the container.

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

app.MapBurgerEndpoints();



app.Run();
