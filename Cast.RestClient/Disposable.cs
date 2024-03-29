﻿namespace Cast.RestClient
{
    public abstract class Disposable : IDisposable
    {
        private bool disposedValue;

        // Dispose pattern implementation called by consumers.
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    DisposeManagedObjects();
                }

                DisposeUnmanagedObjects();
                disposedValue = true;
            }
        }

        protected virtual void DisposeManagedObjects()
        {
        }

        protected virtual void DisposeUnmanagedObjects()
        {
        }
    }
}