using Microsoft.EntityFrameworkCore;
using Integradora_4___ABM_Productos.Entities;

namespace ABMProductos___Base_de_Datos.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
}