using System;

namespace FinalProject
{
    class CurrencyDataServiceException : Exception
    {
        public CurrencyDataServiceException(string msg) : base(msg) { Console.Write(msg); }
    }

}
