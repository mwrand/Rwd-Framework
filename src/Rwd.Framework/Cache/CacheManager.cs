using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;

namespace Rwd.Framework.Cache
{
    public static class CacheManager
    {
        static readonly ObjectCache cache = MemoryCache.Default;

        public static T Get<T>(string key) where T : class
        {
            try
            {
                return (T)cache[key];
            }
            catch
            {
                return null;
            }
        }

        public static void Add(object objectToCache, string key)
        {
            if (objectToCache != null)
                cache.Add(key, objectToCache, DateTime.Now.AddMinutes(30));
        }

        public static void ClearItem(string key)
        {
            MemoryCache.Default.Remove(key);
        }

        public static void ClearAll()
        {
            cache.ToList().ForEach(a => cache.Remove(a.Key));
        }
 
    }
}
