using System;

namespace Prova.Domain.ValueObjects
{
    public class IP
    {
        string _address = "";

        public IP(string address)
        {
            _address = address;
        }

        public string Value => _address;

        public bool IsValid()
        {
            if (String.IsNullOrWhiteSpace(_address))
            {
                return false;
            }

            string[] _splitvalues = _address.Split('.');

            if (_splitvalues.Length != 4)
            {
                return false;
            }

            byte _tempforparsing;

            return _splitvalues.All(r => byte.TryParse(r, out _tempforparsing));
        }
    }
}
