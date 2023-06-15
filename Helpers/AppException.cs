using System;
using System.Globalization;

namespace glasnost_back.Helpers
{
    public class AppException : Exception
    {
        public AppException() : base() { }

        public AppException(string message) : base(message) { }

        public AppException(string message, params object[] args)
            : base(String.Format(new CultureInfo("pt-BR", false), message, args))
        {

        }
    }
}
