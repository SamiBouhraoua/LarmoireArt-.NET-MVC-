using LarmoireArt.Data.Cart;
using Microsoft.AspNetCore.Mvc;

namespace LarmoireArt.Data.ViewComponents
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;
        public ShoppingCartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }
        //Nous devons invoquer la méthode concernée dans ce viewcomponent
        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            return View(items.Count);
        }
    }

}
