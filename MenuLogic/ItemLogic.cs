using MenuLogic.Domain;
using MenuRepository.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuLogic
{
    public class ItemLogic : IItemLogic
    {
        private readonly MenuRepository.ItemTable _db;

        public ItemLogic()
        {
            _db = new MenuRepository.ItemTable();
        }

        public async Task<IEnumerable<ItemLogicModel>> GetItem(int shopID, int optionID)
        {
            IEnumerable<Item> data = await _db.Get(shopID, optionID);
            return data.Select(i => new ItemLogicModel()
            {
                ID = i.ID,
                Name = i.Name,
                Price = i.Price,
                ShopID = i.ShopID,
            });
        }

        public async Task<int> AddItem(int shopID, string itemName, int price)
        {
            Item item = new Item()
            {
                Name = itemName,
                ShopID = shopID,
                Price = price
            };

            item = await _db.Add(item);

            return item.ID;
        }

        public async Task UpdateItem(int id, int shopID, string itemName, int price)
        {
            Item item = new Item()
            {
                ID = id,
                Name = itemName,
                ShopID = shopID,
                Price = price
            };

            await _db.Update(item);
        }

        public async Task DeleteItem(int id)
        {
            await _db.Delete(id);
        }
    }
}
