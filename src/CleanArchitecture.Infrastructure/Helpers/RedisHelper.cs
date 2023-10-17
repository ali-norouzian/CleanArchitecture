using Infrastructure.Settings;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class RedisHelper
    {
        private readonly IDistributedCache _cache;
        private readonly IConnectionMultiplexer _connectionMultiplexer;
        private readonly RedisSetting _redisSetting;
        public RedisHelper(IDistributedCache cache, IOptions<RedisSetting> option, IConnectionMultiplexer connectionMultiplexer)
        {
            _cache = cache;
            _redisSetting = option.Value;
            _connectionMultiplexer = connectionMultiplexer;
        }
        public async Task SetAsync<T>(string key, T value)
        {
            var content = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(value));
            await _cache.SetAsync(key, content);
        }

        public async Task<T> GetAsync<T>(string key)
        {
            var content = await _cache.GetStringAsync(key);

            if (content == null)
                return default(T);
            var result = JsonSerializer.Deserialize<T>(content);
            return result;

        }

        public async Task RemoveAsync(string key)
        {
            await _cache.RemoveAsync(key);
        }

        public async Task<List<T>> GetAllAsync<T>(string entity)
        {
            var redisKeys = _connectionMultiplexer.GetServer(_redisSetting.Ip, _redisSetting.Port).Keys(pattern: $"{entity}_*")
                   .AsQueryable().Select(p => p.ToString()).ToList();

            var result = new List<T>();

            foreach (var redisKey in redisKeys)
            {
                result.Add(JsonSerializer.Deserialize<T>(await _cache.GetStringAsync(redisKey)));
            }

            return result;
        }

    }
}
