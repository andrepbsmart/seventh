using System;

using Prova.Domain.Entities;

namespace Prova.Domain.Interfaces
{
    public interface IServer
    {
        Task SaveAsync(Server server);
        Task UpdateAsync(Server server);
        Task DeleteAsync(string idserver);
        Task<bool> CheckAvailable(string idserver);

        Task<Server> FindById(string idserver);
        Task<IList<Server>> ListAllServers();
    }
}
