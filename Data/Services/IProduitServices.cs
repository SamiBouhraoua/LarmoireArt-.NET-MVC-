
using LarmoireArt.Models;

namespace LarmoireArt.Data.Services
{
    public interface IProduitServices
    {
        Task<IEnumerable<Produit>> GetAllAsync();
        Task<Produit> GetByIdAsync(int id);
        Task<bool> AddNewAsync(Produit produit);
        Task<Produit> UpdateAsync(int id, Produit produit);
        Task DeleteAsync(int id);
    }
}
