using System;

using Microsoft.EntityFrameworkCore;

using Prova.Domain.Core;
using Prova.Domain.Entities;
using Prova.Domain.Interfaces;

using Prova.Data.Context;

namespace Prova.Data.Repositorys
{
    public class ServerRepository : IServer
    {
        private readonly PostgreContext _context;

        public ServerRepository(PostgreContext context)
        {
            _context = context;
        }
        public async Task SaveAsync(Server server)
        {
            _context.Entry(server).State = EntityState.Added;
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Server server)
        {
            _context.Servers.Attach(server);
            _context.Servers.Update(server);
            _context.Entry(server).Property(x => x.CreationDate).IsModified = false;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(string idserver)
        {
            var server = _context.Servers.Where(x => x.idServer == idserver).FirstOrDefault();
            if (server == null)
            {
                throw new BusinessException("Servidor não encontrado");
            }
            _context.Servers.Attach(server);
            _context.Servers.Remove(server);
            await _context.SaveChangesAsync();
        }
        public Task<bool> CheckAvailable(string idserver)
        {
            throw new NotImplementedException();
        }       
        public async Task<Server> FindById(string idserver)
        {
            return await _context.Servers.FindAsync(idserver);
        }
        public async Task<IList<Server>> ListAllServers()
        {
            return await _context.Servers.ToListAsync();
        }
    }
}
