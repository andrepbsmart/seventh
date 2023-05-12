using System;

using MediatR;

using Prova.Domain.Entities;

using Prova.Application.Responses;

namespace Prova.Application.Commands
{
    public class ServersQueryAll : IRequest<ServerResponse>
    {
        public int Page { get; set; } = 1;
        public int ItensPerPage { get; set; } = 20;
    }

    public class ServersQueryGetbyId : IRequest<ServerResponseDetail>
    {
        public string idServer { get; set; }
    }

    public class ServersQueryCheckAvailablebyId : IRequest<Response>
    {
        public string idServer { get; set; }
    }
}
