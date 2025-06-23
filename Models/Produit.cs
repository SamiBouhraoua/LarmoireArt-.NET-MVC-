using System.ComponentModel.DataAnnotations;

namespace LarmoireArt.Models
{
    public class Produit
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "ImageUrl")]
        [Required(ErrorMessage = "l'image est requise")]
        public String? ImageUrl { get; set; }


        [Required(ErrorMessage = "le titre est requis")]
        [Display(Name = "Titre")]
        public String? Titre { get; set; }


        [Required(ErrorMessage = "la description  est requis")]
        [Display(Name = "Description ")]
        public String? Description { get; set; }


        [Required(ErrorMessage = "le prix est requis")]
        [Display(Name = "Prix")]
        public Double Prix { get; set; }


        [Required(ErrorMessage = "le stock est requise")]
        [Display(Name = "Stock")]
        public int Stock { get; set; }


        [Required(ErrorMessage = "La catégorie est requise")]
        [Display(Name = "Categorie")]
        public string? Categorie { get; set; }
    }
}
