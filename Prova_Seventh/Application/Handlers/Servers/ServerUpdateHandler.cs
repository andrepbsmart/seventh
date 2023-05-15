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
    public class ServerUpdateHandler : IRequestHandler<ServerCommandCreate, Response>
    {
        private readonly IServer _repository;

        public ServerUpdateHandler(IServer repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(ServerCommandCreate request, CancellationToken cancelationtoken)
        {
            try
            {
                Server dados = request;

                await _repository.SaveAsync(dados);

                return new Response { Message = Constants_Message.STATUS_CODE_SUCCESS, StatusCode = Constants_Code.STATUS_CODE_SUCCESS };
            }
            catch (BusinessException ex)
            {
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_BADREQUEST };
            }
            catch (Exception ex)
            {
                return new Response { Message = ex.Message, StatusCode = Constants_Code.STATUS_CODE_INTERNAL_SERVER_ERROR };
            }
        }
    }
}
