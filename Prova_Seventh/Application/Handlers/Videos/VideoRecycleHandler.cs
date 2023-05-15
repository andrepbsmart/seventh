using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Prova.Application.Commands;
using Prova.Application.Responses;

using Prova.Domain.Core;
using Prova.Domain.Entities;
using Prova.Domain.Interfaces;

namespace Prova.Application.Handlers.Videos
{
    public class VideoRecycleHandler : IRequestHandler<VideoCommandRecycle, Response>
    {
        public VideoRecycleHandler()
        {

        }

        public async Task<Response> Handle(VideoCommandRecycle request, CancellationToken cancelationtoken)
        {
            try
            {
                //Video dados = request;

                //await _repository.SaveAsync(dados);

                return new Response { Message = Constants_Message.STATUS_CODE_CREATED, StatusCode = Constants_Code.STATUS_CODE_CREATED };
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
