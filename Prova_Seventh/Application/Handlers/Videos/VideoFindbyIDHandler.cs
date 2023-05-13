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
                Video video = _repository.FindById(request.idVideo).Result;

                if (video == null)
                {
                    return null;
                }

                VideoResponseDetail detail = video;

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
