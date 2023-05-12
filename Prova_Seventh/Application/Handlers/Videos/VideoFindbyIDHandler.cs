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
    public class VideoFindbyIDHandler : IRequestHandler<VideosQueryGetbyId, VideoResponseDetail>
    {
        private readonly IVideo _repository;

        public VideoFindbyIDHandler(IVideo repository)
        {
            _repository = repository;
        }
        public async Task<VideoResponseDetail> Handle(VideosQueryGetbyId request, CancellationToken cancellationtoken)
        {
            try
            {
                Video server = _repository.FindById(request.idServer, request.idVideo);

                if (server == null)
                {
                    return null;
                }

                VideoResponseDetail detail = server;

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
