using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRepository
{
    public class ItemTable
    {
        private MenuContext _ctx;

        public ItemTable()
        {
            _ctx = new DesignMenuDbContextFactory().CreateDbContext();
        }

        ~ItemTable()
        {
            _ctx.Dispose();
        }

        public async Task<IEnumerable<Models.Item>> Get(int shopID, int optionID)
        {
            IQueryable<Models.Item> result = from item in _ctx.Items
                                                 .AsNoTracking()
                                                 .Where(i => i.ShopID == shopID)
                                             join itemID in _ctx.ItemOptions
                                                 .AsNoTracking()
                                                 .Where(io => io.OptionID == optionID)
                                                 .Select(io => io.ItemID)
                                             on item.ID equals itemID
                                             select item;
            return await result.ToArrayAsync();
        }

        public async Task<Models.Item> Add(Models.Item item)
        {
            _ctx.Items.Add(item);
            await _ctx.SaveChangesAsync();

            return item;
        }

        public async Task Update(Models.Item item)
        {
            Models.Item currentItem = await _ctx.Items
                .SingleAsync(i => i.ID == item.ID);

            currentItem.Name = item.Name;
            currentItem.Price = item.Price;
            currentItem.ShopID = item.ShopID;

            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Models.Item currentItem = await _ctx.Items
                .SingleAsync(i => i.ID == id);

            _ctx.Remove(currentItem);

            await _ctx.SaveChangesAsync();
        }
    }
}
