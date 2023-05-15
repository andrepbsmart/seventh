using System;

namespace Prova.Domain.Interfaces
{
    public interface IUnityofWork : IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void Rollback();
    }
}
