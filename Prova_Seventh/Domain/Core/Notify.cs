using System;

namespace Prova.Domain.Core
{
    public class Notify
    {

        private readonly List<BrokenRules> listerrors;

        public bool HasNotifications => listerrors.Count > 0;
        public List<BrokenRules> NotificationList => listerrors;

        public Notify()
        {
            listerrors = new();
        }
        public void Add(string key, string message)
        {
            listerrors.Add(new BrokenRules(key, message));
        }
        public override string ToString()
        {
             List<string> _erros;
            if (listerrors.Count == 0)
            {
                return "";
            }
            else
            {
                _erros = new List<string>();
                _erros = listerrors.Select(e => e.Message).ToList();

                return string.Join(";", _erros);
            }
        }
    }
}
