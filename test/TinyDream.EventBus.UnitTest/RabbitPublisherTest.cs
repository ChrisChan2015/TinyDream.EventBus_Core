using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TinyDream.EventBus;
using TinyDream.EventBus.RabbitMQ;

namespace TinyDream.EventBus.UnitTest
{
    public class RabbitPublisherTest
    {
        protected RabbitOptions Options;
        protected TestMessage Message;

        public RabbitPublisherTest()
        {
            Options = new RabbitOptions
            {
                Host = "localhost",
                Queue = "Test"
            };
        }

        protected TestMessage GetTestMessage()
        {
            Random rand = new Random();
            var message = new TestMessage();
            message.Id = rand.Next(1, 101);
            message.Name = Guid.NewGuid().ToString("N");
            message.BirthDay = DateTime.Now;

            return message;
        }

        [Fact]
        public void Publish()
        {
            RabbitOptions options = new RabbitOptions
            {
                Host = "localhost",
                Queue = "Test"
            };

            IPublisher<TestMessage> pubs = new RabbitPublisher<TestMessage>(options);
            pubs.Init();

            var message = GetTestMessage();

            pubs.Publish(message);
        }
    }
}
