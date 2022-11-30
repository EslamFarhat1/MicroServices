using Basket.API.Entiites;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepostiory:IBasketRepository
    {
        private readonly IDistributedCache _rediscashe;

        public BasketRepostiory(IDistributedCache cashe)
        {
            _rediscashe = cashe;
        }

        public async Task Delete(string userName)
        {
            await _rediscashe.RemoveAsync(userName);
        }

        public async Task<ShoppingCart>  getBasket(string userName)
        {
            var result = await _rediscashe.GetStringAsync(userName);
            if (string.IsNullOrEmpty(result))
            {
                return null;
            }
            return JsonConvert.DeserializeObject<ShoppingCart>(result);

        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart cart)
        {
            await _rediscashe.SetStringAsync(cart.UserName,JsonConvert.SerializeObject( cart));
            return await getBasket(cart.UserName);
        }
    }
}
