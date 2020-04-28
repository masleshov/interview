using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxCacheCount = 10;

            var cache = new BlockingCollection<Key>(maxCacheCount);
            var producer = new Producer(cache);
            var dispatcher = new MessageDispatcher(new List<MessageSender> { new MessageSender(), new MessageSender() });
            var consumer = new Consumer(cache, dispatcher);

            var producerTask = producer.FillCacheAsync();
            var consumerTask = consumer.ProcessCachedDataAsync();
            var dispatcherTask = dispatcher.StartProcessingMessagesAsync();

            Task.WaitAll(producerTask, consumerTask, dispatcherTask);
        }
    }
}
