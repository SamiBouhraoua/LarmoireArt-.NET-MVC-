using LarmoireArt.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LarmoireArt.Data;
using LarmoireArt.Data.Services;
using LarmoireArt.Data.Cart;
using Football.Models;

namespace LarmoireArt.Controllers
{
    public class ProduitController : Controller
    {
        private readonly IProduitServices _service;

        public ProduitController(IProduitServices service)
        {
            _service = service;
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProduits = await _service.GetAllAsync();
            if (!string.IsNullOrEmpty(searchString))
            {
                searchString = searchString.ToLower();
                var filteredResult = allProduits
                    .Where(n => n.Titre.ToLower().Contains(searchString) || n.Description.ToLower().Contains(searchString))
                    .ToList();
                return View("Index", filteredResult);
            }

            // Si aucune recherche n'est effectuée, afficher tous les produits
            return View("Index", allProduits);
        }


        public async Task<IActionResult> Index()
        {
            var allProduits = await _service.GetAllAsync();
            ViewBag.ListeCategories = Categories.ListeCategories;
            return View(allProduits);
        }

        public IActionResult Create()
        {
            ViewBag.ListeCategories = Categories.ListeCategories;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ImageUrl,Titre,Description,Prix,Stock,Categorie")] Produit produit)
        {
            if (ModelState.IsValid)
            {
                //verifier que le produit existe deja 
                if (!await _service.AddNewAsync(produit))
                {
                    ModelState.AddModelError("Titre", "Ce produit existe déjà");
                    return View(produit);
                }
                return RedirectToAction(nameof(Index));
            }
            return View(produit);

        }

        public async Task<IActionResult> Details(int id)
        {
            var produitDetails = await _service.GetByIdAsync(id);

            if (produitDetails == null) return View("NotFound");
            return View(produitDetails);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var produitDetails = await _service.GetByIdAsync(id);
            ViewBag.ListeCategories = Categories.ListeCategories;
            if (produitDetails == null) return View("NotFound");
            return View(produitDetails);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ImageUrl,Titre,Description,Prix,Stock,Categorie")] Produit produit)
        {
            if (!ModelState.IsValid)
            {
                return View(produit);
            }

            await _service.UpdateAsync(id, produit);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var produitDetails = await _service.GetByIdAsync(id);

            if (produitDetails == null) return View("NotFound");
            return View(produitDetails);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var produitDetails = await _service.GetByIdAsync(id);
            if (produitDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
