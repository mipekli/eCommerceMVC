using eCommerceMVC.Data;
using eCommerceMVC.Interfaces;
using eCommerceMVC.Models;
using eCommerceMVC.Services;

namespace eCommerceMVC.Repositories;

public class ProductRepository: IProductRepository
{
    private readonly AppDbContext _context;
    
    public ProductRepository (AppDbContext context)
    {
        _context = context;
    }

    public List<Product> GetAll()
    {
        return _context.Products.Where(p => p.IsDeleted == false).ToList();
    }

    public Product GetById(int id)
    {
        return _context.Products.FirstOrDefault(p => p.Id == id && p.IsDeleted == false);
    }

    public Product Add(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return product;
    }

    public void Delete(int id)
    {
        var product=_context.Products.FirstOrDefault(p => p.Id == id);
        product.IsDeleted = true;
        _context.SaveChanges();
    }

    public Product Update(Product updated)
    {
        var productUpadte=_context.Products.FirstOrDefault(p=> p.Id== updated.Id);
        if (productUpadte == null)
        {
            return null;
        }
        else
        {
            productUpadte.Name = updated.Name;
            productUpadte.Price = updated.Price;
            _context.SaveChanges();
            return productUpadte;
        }
    }
}