namespace MemberRepository
{
    public class Member
    {
        private MemberContext _ctx;

        public Member()
        {
            _ctx = new DesignMemberDbContextFactory().CreateDbContext();
        }

        ~Member()
        {
            _ctx.Dispose();
        }
    }
}
