using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using EasyNetQ;
using TinyDream.EventBus;
namespace TinyDream.EventBus.RabbitMQ
{
    public class RabbitPublisher<T> : RabbitBase, IPublisher<T>
        where T : MessageBase
    {

        public RabbitPublisher() { }

        public RabbitPublisher(RabbitOptions options)
        {
            this.Options = options;
        }

        public void Init()
        {
            string connStr = CreateConnectString();
            RabbitBus = RabbitHutch.CreateBus(connStr);
        }

        public void Publish(T message)
        {
            if (message == null)
                return;

            RabbitBus.Send(Options.Queue, message);
        }

        public async Task PublishAsync(T message)
        {
            if (message == null)
                return;

            await RabbitBus.SendAsync(Options.Queue, message);
        }
    }
}
