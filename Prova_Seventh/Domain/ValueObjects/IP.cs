using System;

namespace Prova.Domain.ValueObjects
{
    public class ip
    {
        protected ip()
        {

        }
        public ip(string address)
        {
            Value = address;
        }

        public string Value { get; } = string.Empty;

        
        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(Value))
            {
                return false;
            }

            string[] _splitvalues = Value.Split('.');

            if (_splitvalues.Length != 4)
            {
                return false;
            }

            byte _tempforparsing;

            return _splitvalues.All(r => byte.TryParse(r, out _tempforparsing));
        }

        public static implicit operator string(ip addres) => addres.Value;
        public static implicit operator ip(string address) => new(address);
        public override string ToString() => Value;
    }
}
