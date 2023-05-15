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
    public class ServerFindbyIDHandler : IRequestHandler<ServersQueryGetbyId, ServerResponseDetail>
    {
        private readonly IServer _repository;

        public ServerFindbyIDHandler(IServer repository)
        {
            _repository = repository;
        }

        public async Task<ServerResponseDetail> Handle(ServersQueryGetbyId request, CancellationToken cancellationtoken)
        {
            try
            {
                Server server = _repository.FindById(request.idServer).Result;

                if (server == null)
                {
                    return null;
                }

                ServerResponseDetail detail = server;

                return detail;
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
