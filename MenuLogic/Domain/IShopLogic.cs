using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuLogic.Domain
{
    public interface IShopLogic
    {
        Task<int> AddShop(string name);

        Task<IEnumerable<ShopLogicModel>> GetShop(int id = 0, string name =null);

        Task UpdateShop(int id, string name);

        Task DeleteShop(int id);
    }
}
