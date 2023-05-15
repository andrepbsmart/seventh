using System;

using MediatR;

using Prova.Domain.Entities;

using Prova.Application.Responses;

namespace Prova.Application.Commands
{
    public class ServerCommandCreate : IRequest<Response>
    {
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }

        public static implicit operator Server(ServerCommandCreate dto)
             => new Server(dto.Name, dto.IP, dto.Port);
    }
    public class ServerCommandUpdate : IRequest<Response>
    {
        public string idServer { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }

        public static implicit operator Server(ServerCommandUpdate dto)
             => new Server(dto.idServer, dto.Name, dto.IP, dto.Port);
    }
    public class ServerCommandDelete : IRequest<Response>
    {
        public string idServer { get; set; }
    }
}
