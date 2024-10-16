using System;

namespace AMS.UI.Domain.Exceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException(string msg = "You are not authorized!") : base(msg) {}
    }
}
