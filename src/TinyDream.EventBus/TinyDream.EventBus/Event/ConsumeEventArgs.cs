using System;
using System.Collections.Generic;
using System.Text;

namespace TinyDream.EventBus
{
    public class ConsumeEventArgs<T>
        where T : MessageBase
    {
        public T Message { get; set; }
    }
}
