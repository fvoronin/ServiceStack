using System;
using System.Net;

namespace ServiceStack.ServiceHost
{
    public interface ICookies
    {
        void DeleteCookie(string cookieName);
        void AddCookie(Cookie cookie);
#if !NETCF
        void AddPermanentCookie(string cookieName, string cookieValue, bool? secureOnly = null);
        void AddSessionCookie(string cookieName, string cookieValue, bool? secureOnly = null);
#else
#endif
    }
}