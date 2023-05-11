using System;

using Prova.Domain.Core;
using Prova.Domain.ValueObjects;

namespace Prova.Domain.Entities
{
    public class Server
    {
        private readonly Notify _notify;

        protected Server()
        {
            _notify = new();
        }
        public Server(string name, string ip, int port)
        {
            _notify = new();

            idServer = Guid.NewGuid().ToString();
            Name = name;
            IP = new(ip);
            Port = port;
            CreationDate = DateTime.Today;

            ValidationRules(false);
        }
        public Server(string idserver, string name, string ip, int port)
        {
            _notify = new();

            idServer = idserver;
            Name = name;
            IP = new(ip);
            Port = port;

            ValidationRules(true);
        }

        public string idServer { get; protected set; }
        public string Name { get; protected set; }
        public IP IP { get; protected set; }
        public int Port { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        public Notify Notification => _notify;

        private void ValidationRules(bool update)
        {
            if (string.IsNullOrEmpty(idServer) && update == true)
            {
                _notify.Add(nameof(idServer), "ID não informado");
            }

            if (string.IsNullOrEmpty(Name))
            {
                _notify.Add(nameof(Name), "Nome do servidor não informado");
            }

            if (string.IsNullOrEmpty(IP.Value))
            {
                _notify.Add(nameof(IP), "IP do servidor não informado");
            }

            if (!IP.IsValid())
            {
                _notify.Add(nameof(IP), "Endereço IP do servidor inválido");
            }

            if (Port == 0)
            {
                _notify.Add(nameof(Port), "Porta do servidor não informada");
            }

            if (_notify.HasNotifications == true)
            {
                throw new BusinessException("Existem notificações de validação do objeto !!!", _notify);
            }
        }
    }
}
