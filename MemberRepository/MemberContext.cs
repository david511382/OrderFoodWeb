
using Microsoft.EntityFrameworkCore;
namespace MemberRepository
{
    public class MemberContext : DbContext
    {
        public DbSet<Models.Member> Member { get; set; }

        public MemberContext(DbContextOptions<MemberContext> options)
               : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Models.Member>()
                .HasIndex(c => new { c.Username, c.Password, c.Name });

            modelBuilder.Entity<Models.Member>()
                .HasIndex(c => c.Username)
                .IsUnique();
        }
    }
}
