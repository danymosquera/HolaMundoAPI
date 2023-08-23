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

        public IEnumerable<Product> GetProduts()
        {
            return this._context.Products.OrderBy(p => p.Name);
        }

        public void AddProduct(Product product)
        {
            this._context.Products.Add(product);
        }

        public void UpdateProduct(Product product)
        {
            this._context.Products.Update(product);
        }

        public void DeleteProduct(Product product)
        {
            this._context.Products.Remove(product);
        }

        public async Task<bool> SaveAllAsync()
        { 
         return await this._context.SaveChangesAsync() > 0;
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
