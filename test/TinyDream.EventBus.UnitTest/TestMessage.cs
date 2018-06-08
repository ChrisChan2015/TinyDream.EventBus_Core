using System;
using System.Collections.Generic;
using System.Text;
using TinyDream.EventBus;
namespace TinyDream.EventBus.UnitTest
{
    public class TestMessage : MessageBase
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime BirthDay { get; set; }
    }
}
