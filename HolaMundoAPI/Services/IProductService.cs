using HolaMundoAPI.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HolaMundoAPI.Services
{
    public interface IProductService
    {
        Task<Product>? GetProductAsync(int id);

        IQueryable GetAllWithUsers();

        IEnumerable<SelectListItem> GetComboProducts();
    }
}
