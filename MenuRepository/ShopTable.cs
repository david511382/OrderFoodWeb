using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuRepository
{
    public class ShopTable
    {
        private MenuContext _ctx;

        public ShopTable()
        {
            _ctx = new DesignMenuDbContextFactory().CreateDbContext();
        }

        ~ShopTable()
        {
            _ctx.Dispose();
        }

        public async Task<IEnumerable<Models.Shop>> All()
        {
            return await _ctx.Shops
                .AsNoTracking()
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Models.Shop>> Get(int id)
        {
            return await _ctx.Shops
                .AsNoTracking()
                .Where(s => s.ID == id)
                .ToArrayAsync();
        }

        public async Task<IEnumerable<Models.Shop>> GetByName(string name)
        {
            return await _ctx.Shops
                .AsNoTracking()
                .Where(s => s.Name == name)
                .ToArrayAsync();
        }

        public async Task<Models.Shop> Add(Models.Shop shop)
        {
            _ctx.Shops.Add(shop);
            await _ctx.SaveChangesAsync();

            return shop;
        }

        public async Task Update(Models.Shop shop)
        {
            Models.Shop currentItem = await _ctx.Shops
                .SingleAsync(i => i.ID == shop.ID);

            currentItem.Name = shop.Name;

            await _ctx.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            Models.Shop currentItem = await _ctx.Shops
                .SingleAsync(i => i.ID == id);

            _ctx.Remove(currentItem);

            await _ctx.SaveChangesAsync();
        }
    }
}
