using LarmoireArt.Models;
using Microsoft.EntityFrameworkCore;
using System.Net.Quic;

namespace LarmoireArt.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) 
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Produit> Produits { get; set; }

        //ajout des tables pour la gestion des commandes
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        //ajout de la table 
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}

