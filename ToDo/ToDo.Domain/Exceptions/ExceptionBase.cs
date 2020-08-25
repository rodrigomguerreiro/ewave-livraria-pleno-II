using System;
using System.Net;

namespace ToDo.Domain.Exceptions
{
    public abstract class ExceptionBase : Exception
    {

        public HttpStatusCode Code { get; }

        protected ExceptionBase(string msg) : base(msg)
        {
            Code = HttpStatusCode.BadRequest;
        }

        protected ExceptionBase(string message, HttpStatusCode code) : base(message)
        {
            Code = code;
        }
    }
}
