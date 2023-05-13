using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Prova.Domain.Core;
using Prova.Domain.Interfaces;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.Application.Handlers.Videos
{
    public class VideoDeleteHandler : IRequestHandler<VideoCommandDelete, Response>
    {
        private readonly IVideo _repository;

        public VideoDeleteHandler(IVideo repository)
        {
            _repository = repository;
        }

        public async Task<Response> Handle(VideoCommandDelete request, CancellationToken cancelationtoken)
        {
            try
            {
                await _repository.DeleteAsync(request.idVideo);

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
