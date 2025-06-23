using System.ComponentModel.DataAnnotations;

namespace LarmoireArt.Models
{
    public class ShoppingCartItem
    {
        [Key]
        public int Id { get; set; }
        public Produit Produit { get; set; }
        public int Amount { get; set; }

        //ID unique de panier pour chaque users,utilise pour relier les articles au bon panier
        public string ShoppingCartId { get; set; }
    }
}