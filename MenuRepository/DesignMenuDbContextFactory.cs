using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MenuRepository
{
    internal class DesignMenuDbContextFactory : IDesignTimeDbContextFactory<MenuContext>
    {
        public MenuContext CreateDbContext(params string[] args)
        {
            DbContextOptionsBuilder<MenuContext> builder = new DbContextOptionsBuilder<MenuContext>();
            string connectionString = "Server=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=OrderFoodMenu;Persist Security Info=True;User ID=orderfoodAPI;Password=orderfood;TrustServerCertificate=False;";
            builder.UseSqlServer(connectionString);
            return new MenuContext(builder.Options);
        }
    }
}
