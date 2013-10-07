using CreateRequest.MessageTypes.Requests;
using CreateRequest.MessageTypes.Responses;
using EasyNetQ;

namespace CreateRequest.Subscribers.Responders
{

    public class TestRequestResponder : IResponder
    {
        private readonly IBus _bus;
        public TestRequestResponder(IBus bus)
        {
            _bus = bus;
        }
        public void Subscribe()
        {
            _bus.Respond<TestRequest, TestResponse>(Responce);
        
        }

        private TestResponse Responce(TestRequest request)
        {
           return new TestResponse {Response = " ***** Response to Request *****"};
        }
    }
}