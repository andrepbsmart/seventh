using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Prova.Domain.Core;
using Prova.Domain.Entities;
using Prova.Domain.Interfaces;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.Application.Handlers.Servers
{
    public class ServerListAllHandler : IRequestHandler<ServersQueryAll, ServerResponse>
    {
        private readonly IServer _repository;

        public ServerListAllHandler(IServer repository)
        {
            _repository = repository;
        }

        public async Task<ServerResponse> Handle(ServersQueryAll request, CancellationToken cancellationtoken)
        {
            try
            {
                IEnumerable<Server> servers = await _repository.ListAllServers();

                ServerResponse response = new ServerResponse
                {
                    Data = servers.Select(servers => new ServerResponseItem
                    {
                        idServer = servers.idServer,
                        Name = servers.Name,
                        IP = servers.IP,
                        Port = servers.Port,
                    }).Skip(request.ItensPerPage * (request.Page - 1)).Take(request.ItensPerPage).ToList(),

                    Page = request.Page,
                    PerPage = request.ItensPerPage
                };
                return response;
            }
            catch (BusinessException ex)
            {
                throw new BusinessException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
