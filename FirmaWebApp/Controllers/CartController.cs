using Firma.Data.Model;
using FirmaWebApp.Models.BusinessLogic;
using FirmaWebApp.Models.Shop;
using Microsoft.AspNetCore.Mvc;

namespace FirmaWebApp.Controllers
{
    public class CartController : Controller
    {
        private readonly FirmaDbContext _context;
        public CartController(FirmaDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            var cartData = new CartData
            {
                CartItems = await cart.GetCartItems(),
                Total = await cart.GetTotal()
            };
            return View(cartData);
        }
        
        public async Task<ActionResult> AddToCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.AddToCart(await _context.Produkty.FindAsync(id));
            return RedirectToAction("Index");
        }

        public async Task<ActionResult> RemoveFromCart(int id)
        {
            CartB cart = new CartB(this._context, this.HttpContext);
            cart.RemoveFromCart(id);
            return RedirectToAction("Index");
        }

    }
}
