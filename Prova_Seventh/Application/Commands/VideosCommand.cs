using System;

using MediatR;

using Prova.Domain.Entities;

using Prova.Application.Responses;

namespace Prova.Application.Commands
{
    public class VideoCommandCreate : IRequest<Response>
    {
        public string idServer { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }

        public static implicit operator Video(VideoCommandCreate dto)
             => new Video(dto.idServer, dto.Description, dto.Content);
    }

    public class VideoCommandDelete : IRequest<Response>
    {
        public string idServer { get; set; }
        public string idVideo { get; set; }
    }
    public class VideoCommandRecycle : IRequest<Response>
    {
        public int Days { get; set; }
    }
}
