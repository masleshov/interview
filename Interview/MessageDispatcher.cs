using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Interview
{
    public class MessageDispatcher
    {
        private List<MessageSender> _senders;
        
        public bool NeedClearCache
        {
            get { return _senders.Min(s => s.TimeToDelete) < DateTime.Now; }
        }

        public MessageDispatcher(IEnumerable<MessageSender> senders)
        {
            _senders = senders as List<MessageSender> ?? senders.ToList();
        }

        public async Task StartProcessingMessagesAsync()
        {
            var tasks = _senders.Select(s => s.ProcessMessagesAsync());
            await Task.WhenAll(tasks);
        }
    }
}