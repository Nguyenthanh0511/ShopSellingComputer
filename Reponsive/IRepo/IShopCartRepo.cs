using Model.Entity;
using ServiceComputer.Reponsive.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceComputer.Reponsive.IRepo
{
    public interface IShopCartRepo : IReponsive<ShopCart>
    {
        Task<List<ShopCart>> AddToCart(User user, Product product, int quantity);
    }
}