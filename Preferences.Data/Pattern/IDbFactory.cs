using System;
using Preferences.Data.Context;

namespace Preferences.Data.Pattern
{
    public interface IDbFactory : IDisposable
    {
        PreferenceContext Init();
    }
}
