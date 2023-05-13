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
    public class VideoListAllHandler : IRequestHandler<VideosQueryAll, VideoResponse>
    {
        private readonly IVideo _repository;

        public VideoListAllHandler(IVideo repository)
        {
            _repository = repository;
        }

        public async Task<VideoResponse> Handle(VideosQueryAll request, CancellationToken cancellationtoken)
        {
            try
            {
                IEnumerable<Video> videos = await _repository.ListAllVideos(request.idServer);

                VideoResponse response = new VideoResponse
                {
                    Data = videos.Select(videos => new VideoResponseItem
                    {
                        idVideo = videos.idVideo,
                        idServer = videos.idServer,
                        Description = videos.Description,
                        Content = videos.Content,
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
