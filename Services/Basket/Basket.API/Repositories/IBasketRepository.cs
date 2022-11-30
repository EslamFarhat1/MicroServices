using Basket.API.Entiites;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public interface IBasketRepository
    {
        Task<ShoppingCart> getBasket(string userName);
        Task<ShoppingCart> UpdateBasket(ShoppingCart cart);
        Task Delete(string userName);


    }
}
