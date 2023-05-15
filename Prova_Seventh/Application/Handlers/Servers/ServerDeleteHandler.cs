using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Prova.Domain.Core;
using Prova.Domain.Interfaces;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.Application.Handlers.Servers
{
    public class ServerDeleteHandler : IRequestHandler<ServerCommandDelete, Response>
    {
        private readonly IServer _repository;

        public ServerDeleteHandler(IServer repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(ServerCommandDelete request, CancellationToken cancelationtoken)
        {
            try
            {
                await _repository.DeleteAsync(request.idServer);
               
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
