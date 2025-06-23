using Microsoft.EntityFrameworkCore;
using LarmoireArt.Data.Services;
using LarmoireArt.Models;


namespace LarmoireArt.Data
{
    public class ProduitService : IProduitServices
    {

        private readonly AppDbContext _context;

        public ProduitService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddNewAsync(Produit produit)
        {
            bool produitExiste = await _context.Produits.AnyAsync(a => a.ImageUrl == produit.ImageUrl);
            if (produitExiste)
            {
                return false;

            }
            _context.Produits.Add(produit);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _context.Produits.FirstOrDefaultAsync(a => a.Id == id);
            _context.Produits.Remove(result);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Produit>> GetAllAsync()
        {
            var result = await _context.Produits.OrderBy(a => a.ImageUrl).ToListAsync();
            return result;
        }

        public async Task<Produit> GetByIdAsync(int id)
        {
            var result = await _context.Produits.FirstOrDefaultAsync(a => a.Id == id);
            return result;
        }

        public async Task<Produit> UpdateAsync(int id, Produit produit)
        {
            _context.Update(produit);
            await _context.SaveChangesAsync();
            return produit;
        }

    }
}
