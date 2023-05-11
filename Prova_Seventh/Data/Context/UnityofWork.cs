using System;

using Microsoft.EntityFrameworkCore.Storage;

using Prova.Domain.Interfaces;

namespace Prova.Data.Context
{
    public class UnityofWork : IUnityofWork
    {
        private readonly PostgreContext _context;
        private IDbContextTransaction _transaction;

        public UnityofWork(PostgreContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            _transaction = _context.Database.BeginTransaction();
        }
        public void CommitTransaction()
        {
            _transaction.Commit();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public void Rollback()
        {
            _transaction.Rollback();
        }
    }
}
