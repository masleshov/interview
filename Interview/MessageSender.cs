using System;
using System.Threading.Tasks;

namespace Interview
{
    public class MessageSender
    {
        private Random _random = new Random();

        public DateTime TimeToDelete { get; private set; }
        
        public async Task ProcessMessagesAsync()
        {
            await Task.Run(() => SendMessage());
        }

        private void SendMessage()
        {
            while (true)
            {
                int additionalTime = _random.Next(-100, 100);
                TimeToDelete = DateTime.Now.AddMilliseconds(additionalTime);
            }
        }
    }
}