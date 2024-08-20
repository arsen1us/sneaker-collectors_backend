namespace sneaker_collectors_backend.Services
{
    public static class HttpClientSingleton
    {
        private static HttpClient _client;

        private static readonly object _lock = new object();

        public static HttpClient Client
        {
            get
            {
                lock (_lock)
                {
                    if( _client is null )
                        return new HttpClient();
                    _client = new HttpClient();
                    return _client;
                }
            }
        }
    }
}
