using System.Collections.Generic;

namespace Basket.API.Entiites
{
    public class ShoppingCart
    {
        public string UserName { get; set; }
        public List<ShoppingCartItem> shoppingCartItems { get; set; }=new List<ShoppingCartItem>(){ };
        public ShoppingCart()
        {

        }
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        public decimal TotalPrice
        {
            get
            {
                decimal totalPrice = 0;
                foreach (var item in shoppingCartItems)
                {
                    totalPrice += item.Price*item.Quantity;
                }
                return totalPrice;
            }
        }
    }
}
