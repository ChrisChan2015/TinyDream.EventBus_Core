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
            IPublisher<TestMessage> pubs = new RabbitPublisher<TestMessage>(Options);
            pubs.Init();

            var message = GetTestMessage();

            pubs.Publish(message);
        }
        
        [Fact]
        public void Subscriber()
        {
            ISubscriber<TestMessage> sub = new RabbitSubscriber<TestMessage>(Options);

            sub.ConsumeEvent += (sender,args)=>
            {
                Assert.NotNull(args.Message);
            };
            sub.Init();
        }

    }
}
