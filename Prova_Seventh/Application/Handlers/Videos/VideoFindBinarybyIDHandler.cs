using System;
using System.Threading;
using System.Threading.Tasks;

using MediatR;

using Prova.Domain.Core;
using Prova.Domain.Entities;
using Prova.Domain.Interfaces;

using Prova.Application.Commands;
using Prova.Application.Responses;

namespace Prova.Application.Handlers.Videos
{
    public class VideoFindBinarybyIDHandler : IRequestHandler<VideosQueryGetBinarybyId, VideoResponseBinary>
    {
        private readonly IVideo _repository;

        public VideoFindBinarybyIDHandler(IVideo repository)
        {
            _repository = repository;
        }

        public async Task<VideoResponseBinary> Handle(VideosQueryGetBinarybyId request, CancellationToken cancellationtoken)
        {
            try
            {
                string content = _repository.FindBinaryById(request.idVideo).Result;

                VideoResponseBinary retorno = new(content);

                return retorno;
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
