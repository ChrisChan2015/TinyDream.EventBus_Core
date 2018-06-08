using System;
using System.Collections.Generic;
using System.Text;
using TinyDream.EventBus;

namespace TinyDream.EventBus
{
    public interface ISubscriber<T>
        where T : MessageBase
    {
        void Init();

        void Consuming(T message);

        event EventHandler<ConsumeEventArgs<T>> ConsumeEvent;
    }
}
