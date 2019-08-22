using System.Collections.Generic;
using System.Threading.Tasks;

namespace MenuLogic.Domain
{
    public interface IItemLogic
    {
        Task<int> AddItem(int shopID, string itemName, int price);

        Task<IEnumerable<ItemLogicModel>> GetItem(int shopID, int optionID);

        Task UpdateItem(int id, int shopID, string itemName, int price);

        Task DeleteItem(int id);
    }
}
