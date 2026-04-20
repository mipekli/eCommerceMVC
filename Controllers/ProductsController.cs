using Microsoft.AspNetCore.Mvc;
using eCommerceMVC.Models;
using eCommerceMVC.Data;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;

namespace eCommerceMVC.Controllers;

public class ProductsController : Controller
{
    private readonly AppDbContext _context;

    public ProductsController(AppDbContext context)
    {
        _context = context;
    }
    
    public IActionResult Index()
    {
        var products = _context.Products.ToList();
        return View(products);
    }

    public IActionResult Details(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }

    [HttpGet("/api/products")]
    public IActionResult GetAll()
    {
        var products= _context.Products.ToList();
        return Ok(products);
    }

    [HttpGet("/api/products")]
    public IActionResult GetById([FromQuery]int id)
    {
        var products = _context.Products.FirstOrDefault(p => p.Id == id);
        if(products == null)
        {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpPost("/api/products")]
    public IActionResult Create([FromBody] Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
        return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
    }

    [HttpPut("/api/products/{id}")]
    public IActionResult Update(int id, [FromBody] Product updated)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        product.Name=updated.Name;
        product.Price=updated.Price;
        _context.SaveChanges();
        return Ok(product);
    }

    [HttpDelete("/api/products/{id}")]
    public IActionResult Delete(int id)
    {
        var product = _context.Products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        _context.Products.Remove(product);
        return NoContent();
    }

    
}