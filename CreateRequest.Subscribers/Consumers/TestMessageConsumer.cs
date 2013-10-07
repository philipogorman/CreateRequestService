using Castle.Core.Logging;
using CreateRequest.MessageTypes.Messages;
using EasyNetQ.AutoSubscribe;

namespace CreateRequest.Subscribers.Consumers
{
    public class TestMessageConsumer : IConsume<TestMessage>
    {
        private ILogger _logger;

        public ILogger Logger
        {
            get { return _logger ?? (_logger = NullLogger.Instance); }
            set { _logger = value; }
        }



        public void Consume(TestMessage message)
        {
            _logger.InfoFormat("Message recieved {0}", message.Message);
        }

    }
}