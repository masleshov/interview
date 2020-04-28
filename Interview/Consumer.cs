using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace Interview
{
    public class Consumer
    {
        private BlockingCollection<Key> _cache;
        private MessageDispatcher _dispatcher;

        public Consumer(BlockingCollection<Key> cache, MessageDispatcher dispatcher)
        {
            _cache = cache;
            _dispatcher = dispatcher;
        }

        public async Task ProcessCachedDataAsync()
        {
            try
            {
                await Task.Run(() => RemoveKeysFromCache());
            }
            catch (Exception ex)
            {
                ExceptionHandler.Handle(ex);
            }
        }

        private void RemoveKeysFromCache()
        {
            while (true)
            {
                if(!_dispatcher.NeedClearCache) continue;

                Key key;
                if (!_cache.TryTake(out key)) 
                {
                    throw new ArgumentOutOfRangeException("key", "Cache doesn't exists no one key");
                }
            }
        }
    }
}