using Preferences.Data.Context;

namespace Preferences.Data.Pattern
{
    public class DbFactory: Disposable, IDbFactory
    {
        PreferenceContext dbContext;

        public PreferenceContext Init()
        {
            return dbContext ?? (dbContext = new PreferenceContext());
        }

        protected override void DisposeCustom()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
