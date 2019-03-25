using Preferences.Data.Pattern;
using Preferences.Models;

namespace Preferences.Data.Repository
{
    public class PreferenceRepository: EntityBaseRepository<CustomerPreference>, IPreferenceRepository
    {
        public PreferenceRepository(IDbFactory factory)
            : base(factory)
        { }
    }
}
