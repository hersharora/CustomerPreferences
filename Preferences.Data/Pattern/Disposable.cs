using System;

namespace Preferences.Data.Pattern
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCustom();
            }

            isDisposed = true;
        }

        protected virtual void DisposeCustom()
        {
        }
    }
}
