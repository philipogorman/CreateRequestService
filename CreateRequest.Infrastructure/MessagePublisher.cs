﻿using System;
using Castle.Core.Logging;
using EasyNetQ;

namespace CreateRequest.Infrastructure
{
    public interface IMessagePublisher
    {
        void Publish(dynamic message);

        void Request<TRequest, TResponse>(TRequest request, Action<TResponse> onResponse)
            where TRequest : class
            where TResponse : class;

        void Response<TRequest, TResponse>(Func<TRequest, TResponse> onResponse)
            where TRequest : class
            where TResponse : class;
    }
    public class MessagePublisher : IMessagePublisher
    {
        private readonly IBus _bus;
        private readonly ILogger _logger;

        public MessagePublisher(IBus bus, ILogger logger)
        {
            _bus = bus;
            _logger = logger;
        }

        public void Publish(dynamic message)
        {
            try
            {
                using (var publishChannel = _bus.OpenPublishChannel())
                {
                    _logger.InfoFormat("Publishing Message: {0}", message);
                    publishChannel.Publish(message);
                }
            }
            catch (EasyNetQException ex)
            {
                _logger.Error("Publish Message Failed: ", ex);
            }
        }


        public void Request<TRequest, TResponse>(TRequest request, Action<TResponse> onResponse)
            where TRequest : class
            where TResponse : class
        {
            try
            {
                using (var publishChannel = _bus.OpenPublishChannel())
                {
                    _logger.InfoFormat("Publishing Request: {0}", request);
                    publishChannel.Request(request, onResponse);
                }
            }
            catch (EasyNetQException ex)
            {
                _logger.Error("Publish Request Failed: ", ex);
            }
        }

        public void Response<TRequest, TResponse>(Func<TRequest,TResponse> onResponse)
            where TRequest : class
            where TResponse : class
        {
            try
            {
                _logger.InfoFormat("Publishing Response: {0}", onResponse);
                _bus.Respond(onResponse);
            }
            catch (EasyNetQException ex)
            {
                _logger.Error("Respond Failed: ", ex);
            }
        }
    }
}
