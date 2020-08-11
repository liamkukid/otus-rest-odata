using System;

namespace Maxov.Otus.RestAndOdata.ErrorHandling
{
    public sealed class HttpResponseException : Exception
    {
        public int Status { get; set; } = 500;

        public object Value { get; set; }
    }
}