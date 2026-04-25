using eCommerceMVC.Models;

namespace eCommerceMVC.Interfaces;

public interface IProductRepository
{
    List<Product> GetAll();
    Product GetById(int id);
    Product Add(Product product);
    Product Update(Product updated);
    void Delete(int id);
}