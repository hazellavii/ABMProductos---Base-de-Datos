using ABMProductos___Base_de_Datos.Data;
using Integradora_4___ABM_Productos.Entities;
using Integradora_4___ABM_Productos.Repositories.Interfaces;

namespace Integradora_4___ABM_Productos.Repositories.Implementations;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAllProducts()
    {
        return _context.Products.ToList();
    }

    public Product? GetProductById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id);
    }

    public void AddProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(Product product)
    {
        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public List<Product> SearchProductsByName(string name)
    {
        return _context.Products
            .Where(p => p.Name.ToLower().Contains(name.ToLower()))
            .ToList();
    }
}