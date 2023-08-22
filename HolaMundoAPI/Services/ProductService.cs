using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HolaMundoAPI.Data;
using HolaMundoAPI.Data.Models;

namespace HolaMundoAPI.Services
{
    public class ProductService : IProductService
    {
        private readonly DBContext _context;
        public ProductService(DBContext context) 
        {
            _context = context;
        }

        public async Task<Product>? GetProductAsync(int id)
        {
            if (_context.Products == null)
            {
                return null;
            }
            var product = await _context.Products.FirstOrDefaultAsync(product => product.Id == id);

            return product;
        }

        public IQueryable GetAllWithUsers()
        {
            return this._context.Products.Include(p => p.User);
        }

        public IEnumerable<SelectListItem> GetComboProducts()
        {
            var list = this._context.Products.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.Id.ToString()
            }).ToList();

            list.Insert(0, new SelectListItem
            {
                Text = "(Select a product...)",
                Value = "0"
            });

            return list;
        }
    }
}
