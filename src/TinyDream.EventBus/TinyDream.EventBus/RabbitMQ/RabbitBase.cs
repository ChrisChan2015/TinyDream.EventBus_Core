using System;
using System.Collections.Generic;
using System.Text;
using EasyNetQ;


namespace TinyDream.EventBus.RabbitMQ
{
    public abstract class RabbitBase
    {
        public virtual IBus RabbitBus { get; set; }

        public virtual RabbitOptions Options
        {
            get;
            set;
        }

        public virtual string CreateConnectString()
        {
            StringBuilder connStr = new StringBuilder();
            connStr.AppendFormat("host={0}", Options.Host);

            if (!string.IsNullOrWhiteSpace(Options.VirtualHost))
            {
                connStr.AppendFormat(";virtualHost={0}", Options.VirtualHost);
            }
            if (!string.IsNullOrWhiteSpace(Options.UserName))
            {
                connStr.AppendFormat(";username={0}", Options.UserName);
            }
            if (!string.IsNullOrWhiteSpace(Options.Password))
            {
                connStr.AppendFormat(";password={0}", Options.Password);
            }

            return connStr.ToString();
        }

        public virtual void Dispose()
        {
            RabbitBus.Dispose();
            RabbitBus = null;
        }
    }
}
