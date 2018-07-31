using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prodca.Models;

namespace Prodca.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProdcaContext _context;
        
        public ProductController(ProdcaContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<List<Product>> GetAll()
        {
            return _context.Product.ToList();
        }

        [HttpGet("{id")]
        public ActionResult<Product> GetById(int id)
        {
            Product prod = _context.Product.Find(id);
            if(prod == null)
            {
                return NoContent();
            }
            return prod;
        }

        [HttpPost]
        public ActionResult<Product> Create(Category category, Product product)
        {
            product.Category = category;
            _context.Product.Add(product);
            _context.SaveChanges();
            return product;
        }

    
    }
}