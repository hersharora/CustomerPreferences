using Preferences.Data.Context;

namespace Preferences.Data.Pattern
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory DbFactory;
        private PreferenceContext dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
        }

        public PreferenceContext DbContext
        {
            get { return dbContext ?? (dbContext = DbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.Commit();
        }
    }
}
