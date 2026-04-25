using eCommerceMVC.DTOs;
using eCommerceMVC.Interfaces;
using eCommerceMVC.Models;

namespace eCommerceMVC.Services;

public class ProductService
{
    private readonly IProductRepository _productRepository;
    
    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public List<ProductResponseDto> GetAll()
    {
        var products = _productRepository.GetAll();
        return products.Select(p=> new ProductResponseDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        }).ToList();
    }
    
    public ProductResponseDto GetByID(int id)
    {
        var product = _productRepository.GetById(id);
        if (product == null)
        {
            return null;
        }

        return new ProductResponseDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };
    }
    
    public ProductResponseDto Add(ProductCreateDto dto)
    {
        if (dto.Price <= 0)
        {
            throw new ArgumentException("Fiyat 0'dan büyük olmalıdır.");
        }
        
        if (string.IsNullOrEmpty(dto.Name))
        {
            throw new Exception("Ürün adı boş olamaz.");
        }

        var product = new Product
        {
            Name = dto.Name,
            Price = dto.Price
        };
        
        var crated= _productRepository.Add(product);
        return new ProductResponseDto
        {
            Id = crated.Id,
            Name = crated.Name,
            Price = crated.Price
        };
    }

    
    
    public Product Update(Product product)
        {
            if (product.Price <= 0)
            {
                throw new Exception("Fiyat 0'dan büyük olmalıdır.");
            }
            
            if (string.IsNullOrEmpty(product.Name))
            {
                throw new Exception("Ürün adı boş olamaz.");
            }
            
            return _productRepository.Update(product);
        }
    
        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }


    
}