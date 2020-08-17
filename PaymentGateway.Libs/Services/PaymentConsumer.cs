using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using PaymentGateway.Libs.Infrastructure;
using PaymentGateway.Libs.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace PaymentGateway.Libs.Services
{
    public class PaymentConsumer : IHostedService
    {
        private readonly IModel _channel;
        private readonly IConnection _connection;
        private readonly IPaymentService _paymentService;
        private readonly IServiceScopeFactory _serviceScopeFactory;

        public PaymentConsumer(IServiceScopeFactory serviceScopeFactory, IPaymentService paymentService)
        {
            _serviceScopeFactory = serviceScopeFactory;
            _paymentService = paymentService;


            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "user",
                Password = "bitnami"
            };

            _connection = factory.CreateConnection();

            _channel = _connection.CreateModel();
        }


        public Task StartAsync(CancellationToken cancellationToken)
        {
            _channel.QueueDeclare("payment_submitted", false, false, false, null);

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var payment = JsonConvert.DeserializeObject<MerchantPayment>(message);

                using (var scope = _serviceScopeFactory.CreateScope())
                {
                    var paymentRepository = scope.ServiceProvider.GetRequiredService<IPaymentRepository>();
                    paymentRepository.Update(payment.Id, payment);

                }
            };

            _channel.BasicConsume(queue: "payment_submitted",
                autoAck: true,
                consumer: consumer);

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _connection.Close();

            return Task.CompletedTask;
        }
    }
}
