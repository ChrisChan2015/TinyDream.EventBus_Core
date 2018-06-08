using System;
using System.Collections.Generic;
using System.Text;
using TinyDream.EventBus;
using EasyNetQ;
using EasyNetQ.Consumer;

namespace TinyDream.EventBus.RabbitMQ
{
    public class RabbitSubscriber<T> : RabbitBase, ISubscriber<T>, IDisposable
        where T : MessageBase
    {

        public event EventHandler<ConsumeEventArgs<T>> ConsumeEvent;

        public RabbitSubscriber() { }

        public RabbitSubscriber(RabbitOptions options)
        {
            this.Options = options;
        }

        public void Init()
        {
            string connStr = CreateConnectString();
            RabbitBus = RabbitHutch.CreateBus(connStr);
            RabbitBus.Receive<T>(Options.Queue, new Action<T>(Consuming));
        }

        public void Consuming(T message)
        {
            ConsumeEventArgs<T> args = new ConsumeEventArgs<T>();
            args.Message = message;

            ConsumeEvent(this, args);
        }

        public void Dispose()
        {
            RabbitBus.Dispose();
            RabbitBus = null;
        }
    }
}
