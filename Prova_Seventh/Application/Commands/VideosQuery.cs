using System;

using MediatR;

using Prova.Domain.Entities;

using Prova.Application.Responses;

namespace Prova.Application.Commands
{
    public class VideosQueryAll : IRequest<VideoResponse>
    {
        public string idServer { get; set; }
        public int Page { get; set; } = 1;
        public int ItensPerPage { get; set; } = 20;
    }

    public class VideosQueryGetbyId : IRequest<VideoResponseDetail>
    {
        public string idVideo { get; set; }
    }

    public class VideosQueryGetBinarybyId : IRequest<VideoResponseBinary>
    {
        public string idVideo { get; set; }
    }
}
