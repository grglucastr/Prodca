using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Prodca.Models;

namespace Prodca.Controllers
{
    [Route("/api[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ProdcaContext _context;

        public CategoryController(ProdcaContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        public ActionResult<List<Category>> GetAll()
        {
            return _context.Category.ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Category> GetById(int id)
        {
            Category category = _context.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return _context.Category.Find(id);
        }

        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            _context.Category.Add(category);
            _context.SaveChanges();
            return category;
        }

        [HttpPut("{id}")]
        public ActionResult<Category> Update(int id, Category item)
        {
            Category category = _context.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }

            category.Name = item.Name;
            _context.Update(category);
            _context.SaveChanges();
            return category;
        }

        [HttpDelete("{id}")]
        public ActionResult<Category> Delete(int id)
        {
            Category category = _context.Category.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            _context.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}