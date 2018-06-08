using System;
using System.Collections.Generic;
using System.Text;

namespace TinyDream.EventBus
{
    public interface IOptions
    {
        string Host { get; set; }

        string VirtualHost { get; set; }

        string UserName { get; set; }

        string Password { get; set; }

        string Queue { get; set; }

        int Timeout { get; set; }
    }
}
