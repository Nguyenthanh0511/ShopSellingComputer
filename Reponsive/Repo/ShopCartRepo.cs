using Model.Entity;
using ServiceComputer.Model.DataModel;
using ServiceComputer.Reponsive.Base;
using ServiceComputer.Reponsive.IRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Reponsive.Repo
{
    public class ShopCartRepo : Reponsive<ShopCart>, IShopCartRepo
    {
        public ShopCartRepo(DBServiceComputerContext context) : base(context)
        {
        }

        public async Task<List<ShopCart>>AddToCart(User user, Product product, int quantity)
        {
            // get all cart
            try
            {

            var listShopCart = await base.GetAll();
                if (listShopCart == null)
                {
                    new List<ShopCart>();
                }
                var cart = listShopCart?.FirstOrDefault(ca => ca.productid == product.Id && ca.UserId == user.Id);
                if(cart == null)
                {
                    Random random = new Random();
                    int randomid = random.Next();
                    cart = new ShopCart()
                    {
                        Id = randomid,
                        UserId = user.Id,
                        productid = product.Id,
                        quantiy = quantity,
                        total = quantity * (product.Price)
                    };
                    await base.CreateRepo(cart);

                }
                else
                {
                cart.quantiy += quantity;
                cart.total = quantity * product.Price;
                await base.UpdateRepo(cart);
                }
                return await base.GetAll();
            }
            catch (Exception ex)
            {
                checkStatus = false;
                noticationErr = ex.Message;
                return null;
            }
        }
    }
}
