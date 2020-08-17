﻿using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using PaymentGateway.Libs.Models;
using RabbitMQ.Client;

namespace PaymentGateway.Libs.Services
{
    public class PaymentPublisher :IPaymentPublisher
    {
        private IModel _channel;
        private IConnection _connection;

        public PaymentPublisher()
        {
            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "bitnami"
            };

                _connection = factory.CreateConnection();
            
                var channel = _connection.CreateModel();
                
                channel.QueueDeclare("payment_submitted", false, false, false, null);
                _channel = channel;

        }

        public void PublishPaymentSubmitted(MerchantPayment payment)
        {
            var json = JsonConvert.SerializeObject(payment);

            var bytes = Encoding.UTF8.GetBytes(json);

            _channel.BasicPublish(exchange: "", "payment_submitted", true, _channel.CreateBasicProperties(), bytes);
        }

    }

    public interface IPaymentPublisher
    {
        void PublishPaymentSubmitted(MerchantPayment payment);
    }
}
