using System;
using Prova.Domain.Core;

namespace Prova.Domain.Entities
{
    public class Video
    {
        private readonly Notify _notify;

        public Video()
        {
            _notify = new();
        }
        public Video(string idserver, string description, string content)
        {
            _notify = new();

            idVideo = Guid.NewGuid().ToString();
            idServer = idserver;
            Description = description;
            Content = content;
            CreationDate = DateTime.Today;

            ValidationRules(false);
        }

        public string idVideo { get; protected set; }
        public string idServer { get; protected set; }
        public string Description { get; protected set; }
        public string Content { get; protected set; }
        public DateTime CreationDate { get; protected set; }

        //public virtual Server Server { get; set; }

        public Notify Notification => _notify;

        private void ValidationRules(bool update)
        {
            if (string.IsNullOrEmpty(idServer))
            {
                _notify.Add(nameof(idServer), "Servidor não informado");
            }

            if (string.IsNullOrEmpty(Description))
            {
                _notify.Add(nameof(Description), "Descrição do vídeo não informada");
            }

            if (string.IsNullOrEmpty(Content))
            {
                _notify.Add(nameof(Content), "Conteúdo binario do video não informado");
            }

            if (_notify.HasNotifications == true)
            {
                throw new BusinessException("Existem notificações de validação do objeto !!!", _notify);
            }
        }
    }
}
