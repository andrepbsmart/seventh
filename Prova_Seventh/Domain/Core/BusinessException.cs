using System;
using System.Collections.Generic;

namespace Prova.Domain.Core
{
    public class BusinessException : Exception
    {
        public Notify Notifications { get; protected set; }

        private BusinessException(string message) : base(message)
        {
            Notifications = new();
        }
        public BusinessException(string message, Notify notification) : base(message)
        {
            Notifications = notification;
        }

        public string Message => Notifications.ToString();
    }
}