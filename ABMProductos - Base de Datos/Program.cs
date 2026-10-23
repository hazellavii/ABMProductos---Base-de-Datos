using Microsoft.EntityFrameworkCore;
using ABMProductos___Base_de_Datos.Data;
using Integradora_4___ABM_Productos.Repositories.Implementations;
using Integradora_4___ABM_Productos.Repositories.Interfaces;
using Integradora_4___ABM_Productos.Services.Implementations;
using Integradora_4___ABM_Productos.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(
        builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();