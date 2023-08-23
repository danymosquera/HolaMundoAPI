using HolaMundoAPI.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolaMundoAPI.Services
{
    public interface IProductService
    {
        Task<Product>? GetProductAsync(int id);

        IQueryable GetAllWithUsers();

        IEnumerable<Product> GetProduts();

        void AddProduct(Product product);

        void UpdateProduct(Product product);

        void DeleteProduct(Product product);

        Task<bool> SaveAllAsync();
        
        IEnumerable<SelectListItem> GetComboProducts();
    }
}
