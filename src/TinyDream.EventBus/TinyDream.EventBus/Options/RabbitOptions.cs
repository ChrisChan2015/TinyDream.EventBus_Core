using System;
using System.Collections.Generic;
using System.Text;
using TinyDream.EventBus;

namespace TinyDream.EventBus.RabbitMQ
{
    public class RabbitOptions : IOptions
    {
        private string _host;
        private string _virtualHost;
        private string _userName;
        private string _password;
        private string _queue;
        private int _timeout;

        public string Host { get => _host; set => _host = value; }
        public string VirtualHost { get => _virtualHost; set => _virtualHost = value; }
        public string UserName { get => _userName; set => _userName = value; }
        public string Password { get => _password; set => _password = value; }
        public string Queue { get => _queue; set => _queue = value; }
        public int Timeout { get => _timeout; set => _timeout = value; }

        public RabbitOptions()
        {

        }

        public RabbitOptions(string host, string queue)
        {
            this.Host = host;
            this.Queue = queue;
        }

        public RabbitOptions(string host, string queue, string userName, string password)
        {
            this.Host = host;
            this.Queue = queue;
            this.UserName = userName;
            this.Password = password;
        }

        public RabbitOptions(string host, string queue, string virtualHost, string userName, string password, int timeout)
        {
            this.Host = host;
            this.VirtualHost = virtualHost;
            this.Queue = queue;
            this.UserName = userName;
            this.Password = password;
            this.Timeout = timeout;
        }
    }
}
