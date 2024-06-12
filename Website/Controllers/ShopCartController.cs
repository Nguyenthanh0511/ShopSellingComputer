using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model.Entity;
using ServiceComputer.Model.DataModel;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;
using ServiceComputer.Reponsive.Repo;
using ServiceComputer.Website.ViewModel;
using System.Linq;
using Website.Models;

namespace ServiceComputer.Website.Controllers
{
    public class ShopCartController : Controller
    {
        private readonly IShopCartRepo _shopcartRepo;
        private readonly IReponsive<Product> _productRepo;
        private readonly IReponsive<User> _userRepo;
        public readonly DBServiceComputerContext _context;
        public ShopCartController(DBServiceComputerContext context, IShopCartRepo shopcart, IReponsive<Product> product, IReponsive<User> user)
        {
            _shopcartRepo = shopcart;
            _productRepo = product;
            _userRepo = user;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var listProduct = await _productRepo.GetAll();
            var listCart = await _shopcartRepo.GetAll();

            if (listProduct == null || listCart == null)
            {
                // Handle the null case appropriately, for example, by returning an error view.
                return View("Error", new ErrorViewModel { RequestId = "No products or cart items found" });
            }

            var listShowCartProduct = from lp in listProduct
                                      join ls in listCart
                                      on lp.Id equals ls.productid
                                      select new {
                                          Product = lp,
                                          ShopCart = ls
                                      };
            var listShowCartView = new ShowCart
            {
                quantity = listShowCartProduct.Sum(x => x.ShopCart.quantiy),
                total = listShowCartProduct.Sum(x => x.Product.Price),
                listProductShowCart = listShowCartProduct.Select(p => p.Product).ToList(),
                listShopCart = listShowCartProduct.Select(p => p.ShopCart).ToList()
            };
            return View(listShowCartView);
        }
        [HttpPost]
        public async Task<IActionResult> AddCart(int userid, int productid, int quantity)
        {
            if(userid == 0)
            {
                return View("Not find user id");
            }
            if(productid == 0)
            {
                return View("Not find product id");
            }
            try
            {
            var product = await _productRepo.GetId(productid);
            var user = await _userRepo.GetId(userid);
            if(product == null || user == null)
            {
                return View("Not find user and product");
            }
            //_shopcartRepo.AddToCart(user, product, quantity);
            var cart = await _context.ShopCarts.FirstOrDefaultAsync(x => x.UserId == userid && x.productid == productid);
            if(cart == null)
            {
                cart = new ShopCart()
                {
                    UserId = user.Id,
                    productid = product.Id,
                    quantiy = quantity,
                    total = product.Price
                };
                _context.ShopCarts.Add(cart);
            }
            else
            {
                cart.quantiy += quantity;
                cart.total = cart.quantiy * product.Price;
                _context.ShopCarts.Update(cart);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
            }
            catch(Exception err)
            {
                return BadRequest(err.Message);
            }
        }
            
    }
}