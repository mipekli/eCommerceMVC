using Microsoft.AspNetCore.Mvc;
using eCommerceMVC.Models;
using eCommerceMVC.Data;
using eCommerceMVC.DTOs;
using eCommerceMVC.Services;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace eCommerceMVC.Controllers;

public class ProductsController : Controller
{
  
    private readonly ProductService _productService;

    public ProductsController(ProductService productService)
    {        _productService = productService;
    }
    
        public IActionResult Index()
        {
            var products = _productService.GetAll();
            return View(products);
        }

        public IActionResult Details(int id)
        {
            var product = _productService.GetByID(id);
            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

    [HttpGet("/api/products")]
    public IActionResult GetAll()
    {
        var products = _productService.GetAll();
        return Ok(products);
    }

    [HttpGet("/api/products/{id}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var products = _productService.GetByID(id);
        if(products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost("/api/products")]
    public IActionResult Create([FromBody] ProductCreateDto dto)
    {
        var product =_productService.Add(dto);
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("/api/products/{id}")]
    public IActionResult Update(int id, [FromBody] Product updated)
    {
        
        var product = _productService.GetByID(id);
        
        
        _productService.Update(updated);
        return Ok(product);
    }

    [HttpDelete("/api/products/{id}")]
    public IActionResult Delete(int id)
    {
        _productService.Delete(id);
        return NoContent();
    }

    
}