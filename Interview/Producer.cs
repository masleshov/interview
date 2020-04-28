using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Interview
{
    public class Producer
    {
        private BlockingCollection<Key> _cache;

        public Producer(BlockingCollection<Key> cache)
        {
            _cache = cache;
        }

        public async Task FillCacheAsync()
        {
            try
            {
                await Task.Run(() => InsertNewKeysToCache());
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void InsertNewKeysToCache()
        {
            while (true)
            {
                var key = new Key();
                if (!_cache.TryAdd(key))
                {
                    //may be we need to try update value here ?
                    throw new ArgumentException($"Key with name {key.Name} already exists in cache", "key");
                }
            }
        }
    }
}