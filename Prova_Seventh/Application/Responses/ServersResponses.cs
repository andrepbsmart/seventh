using System;

using Prova.Domain.Entities;

namespace Prova.Application.Responses
{
    public class ServerResponse
    {
        public List<ServerResponseItem> Data { get; set; }
        public int Page { get; set; }
        public int PerPage { get; set; }
        public int LastPage
        {
            get
            {
                return Data.Count / PerPage + 1;
            }
        }
    }

    public class ServerResponseItem
    {
        public string idServer { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
    }

    public class ServerResponseDetail
    {
        public ServerResponseDetail(string idserver, string name, string ip, int port, DateTime creationdate)
        {
            idServer = idserver;
            Name = name;
            IP = ip;
            Port = port;
            CreationDate = creationdate;
        }

        public string idServer { get; set; }
        public string Name { get; set; }
        public string IP { get; set; }
        public int Port { get; set; }
        public DateTime CreationDate { get; set; }

        public static implicit operator ServerResponseDetail(Server dto)
            => new ServerResponseDetail(dto.idServer, dto.Name, dto.IP, dto.Port, dto.CreationDate);
    }
}
