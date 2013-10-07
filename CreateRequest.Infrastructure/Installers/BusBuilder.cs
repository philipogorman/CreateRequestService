using EasyNetQ;

namespace CreateRequest.Infrastructure.Installers
{
    public class BusBuilder
    {
        public static IBus CreateMessageBus()
        {
            // todo move these in to configs
            return RabbitHutch.CreateBus("host=localhost;virtualHost=/;username=guest;password=guest");
        }
    }
}