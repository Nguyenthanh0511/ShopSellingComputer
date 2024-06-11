using Model.Entity;

namespace ServiceComputer.Website.ViewModel
{
    public class ShowCart
    {
        public List<Product> listProductShowCart {  get; set; }
        public List<ShopCart> listShopCart { get; set; }
        public int quantity {  get; set; }
        public decimal total { get; set; }
    }
}
