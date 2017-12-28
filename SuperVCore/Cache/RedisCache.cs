using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SuperVCore.Cache
{
    public class RedisCache
    {
        private ConnectionMultiplexer _cache;
        private IDatabase _db;

        public RedisCache()
        {
            _cache = ConnectionMultiplexer.Connect("localhost");
            _db = _cache.GetDatabase();
        }

        public RedisCache(ConnectionMultiplexer redis)
        {
            _cache = redis;
            _db = _cache.GetDatabase();
        }

        public object GetKey(string key)
        {
            return _db.StringGet(key);

        }
    }
}
