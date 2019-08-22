using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MemberRepository
{
    internal class DesignMemberDbContextFactory : IDesignTimeDbContextFactory<MemberContext>
    {
        public MemberContext CreateDbContext(params string[] args)
        {
            DbContextOptionsBuilder<MemberContext> builder = new DbContextOptionsBuilder<MemberContext>();
            string connectionString = "Server=(LOCALDB)\\MSSQLLOCALDB;Initial Catalog=OrderFoodMember;Persist Security Info=True;User ID=orderfoodAPI;Password=orderfood;TrustServerCertificate=False;";
            builder.UseSqlServer(connectionString);
            return new MemberContext(builder.Options);
        }
    }
}
