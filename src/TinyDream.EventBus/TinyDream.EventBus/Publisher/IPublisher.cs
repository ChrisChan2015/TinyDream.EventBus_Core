using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TinyDream.EventBus
{
    public interface IPublisher<T>
    {
        void Init();

        void Publish(T message);

        Task PublishAsync(T message);
    }
}
