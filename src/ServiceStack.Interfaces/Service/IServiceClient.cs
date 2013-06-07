using System;

namespace ServiceStack.Service
{
	public interface IServiceClient : 
#if !NETCF
        IServiceClientAsync, 
#endif
        IOneWayClient
#if !(SILVERLIGHT || MONOTOUCH)
		, IReplyClient
#endif
	{
	}

}