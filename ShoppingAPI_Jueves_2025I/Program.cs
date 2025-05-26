using Microsoft.EntityFrameworkCore;
using ShoppingAPI_Jueves_2025I.DAL;
using ShoppingAPI_Jueves_2025I.Domain.Interfaces;
using ShoppingAPI_Jueves_2025I.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Esta es la línea de codigo que necesito para configurar la conexión a la BD
builder.Services.AddDbContext<DataBaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString
    ("DefaultConnection")));

//Contenedor de Dependencias
builder.Services.AddScoped<ICountryService, CountryService>();

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
