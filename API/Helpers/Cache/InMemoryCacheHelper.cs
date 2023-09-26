using Microsoft.Extensions.Caching.Memory;

namespace API.Helpers.Cache
{
    public class InMemoryCacheHelper : ICacheHelper
    {
        private readonly IMemoryCache _memoryCache;
        public InMemoryCacheHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public T? Get<T>(string key)
        {
            try
            {
                _memoryCache.TryGetValue<T>(key, out T cachedObj);

                if (cachedObj == null) { return default; }

                return cachedObj;
            }
            catch (Exception)
            {

                return default;
            }
        }

        public void Set<T>(string key, T value)
        {
            var options = new MemoryCacheEntryOptions
            {
                AbsoluteExpiration = DateTime.Now.AddMinutes(5),
                SlidingExpiration = TimeSpan.FromMinutes(2)
            };

            _memoryCache.Set<T>(key, value, options);
        }
    }
}
