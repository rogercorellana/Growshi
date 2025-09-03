using System;
using System.Runtime.Serialization;

namespace BLL
{
    public class CuentaBloqueadaException : Exception
    {
        public CuentaBloqueadaException(string message) : base(message) { }
    }
}