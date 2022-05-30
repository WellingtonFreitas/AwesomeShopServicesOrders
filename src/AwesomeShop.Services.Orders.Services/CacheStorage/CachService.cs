using AwesomeShop.Services.Orders.Domain.Interfaces.Services;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace AwesomeShop.Services.Orders.Services.CacheStorage
{
    public class CachService : ICachService
    {
        private readonly IDistributedCache _cache;
        public CachService(IDistributedCache cache)
        {
            _cache = cache;
        }
        public async Task<T> GetAsync<T>(string key)
        {
           var objectString = await _cache.GetStringAsync(key);
            if (objectString == null)
                    return default(T);

            return JsonConvert.DeserializeObject<T>(objectString);
        }

        public async Task SetAsync<T>(string key, T data)
        {
            var memoryCacheEntryOptions = new DistributedCacheEntryOptions
            {
                //Expira o cache em 1 hora
                AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(3600),
                // ou expira cache após 20 minutos sem ser acessado
                SlidingExpiration = TimeSpan.FromSeconds(1200),
            };

            var objectString = JsonConvert.SerializeObject(data);
            await _cache.SetStringAsync(key,objectString,memoryCacheEntryOptions);
        }
    }
}
