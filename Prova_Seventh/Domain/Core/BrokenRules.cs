using System;

namespace Prova.Domain.Core
{
    public class BrokenRules
    {
        public BrokenRules(string key, string message)
        {
            Key = key;
            Message = message;
        }
        public string Key { get; protected set; }
        public string Message { get; protected set; }
    }
}
