using MenuLogic.Domain;
using MenuRepository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuLogic
{
    public class ShopLogic : IShopLogic
    {
        private readonly MenuRepository.ShopTable _db;

        public ShopLogic()
        {
            _db = new MenuRepository.ShopTable();
        }

        public async Task<IEnumerable<ShopLogicModel>> GetShop(int id = 0, string name = null)
        {
            Task<IEnumerable<Shop>> get;

            if (id != 0)
                get = _db.Get(id);
            else if (!string.IsNullOrEmpty(name))
                get = _db.GetByName(name);
            else
                get = _db.All();

            IEnumerable<Shop> data = await get;
            return data.Select(i => new ShopLogicModel()
            {
                ID = i.ID,
                Name = i.Name
            });
        }


        public async Task<int> AddShop(string name)
        {
            Shop shop = new Shop()
            {
                Name = name
            };

            shop = await _db.Add(shop);

            return shop.ID;
        }


        public async Task UpdateShop(int id, string name)
        {
            Shop shop = new Shop()
            {
                ID = id,
                Name = name
            };

            await _db.Update(shop);
        }

        public async Task DeleteShop(int id)
        {
            await _db.Delete(id);
        }
    }
}
