using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PaymentGateway.Api.Controllers;
using PaymentGateway.Api.Mappers;
using PaymentGateway.Libs.Infrastructure;
using PaymentGateway.Libs.Models;
using PaymentGateway.Libs.Services;

namespace PaymentGateway.UnitTests
{
    [TestFixture]
    public class GetPaymentShould
    {
        [SetUp]
        public void SetUp()
        {

        }


        [Test]
        public void ReturnOkResponseIfValidRequest()
        {
            //Arrange
            var paymentRepo = new Mock<IPaymentRepository>();
            var profile = new MerchantPaymentProfile();
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(profile));
            var paymentPublisher = new Mock<IPaymentPublisher>();

            var mapper = new Mapper(mapperConfig);
            var id = Guid.NewGuid();

            var payment = new MerchantPayment()
            {
                Id = id,
                Amount = 9.99,
                Currency = "USD",
                MerchantId = "1",
                PaymentMethod = new PaymentMethod
                {
                    Cvv = "123",
                    ExpirationMonth = "05",
                    ExpirationYear = "2021",
                    Number = "4319487612345678",
                    PaymentMethodId = new Guid(),
                    Type = "Visa"
                },
                Status = Status.Submitted
                
            };

            //Act
            paymentRepo.Setup(x => x.GetById(id)).Returns(Task.FromResult(payment));
            var controller = new PaymentController(paymentRepo.Object, mapper, paymentPublisher.Object);

            var result = controller.GetPayment(id);

            //Assert
            Assert.That(result.Result, Is.TypeOf<OkObjectResult>());

        }

        [Test]
        public void ReturnMaskedCardNumberToMerchant()
        {

            //Arrange
            var paymentRepo = new Mock<IPaymentRepository>();
            var profile = new MerchantPaymentProfile();
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(profile));
            var paymentPublisher = new Mock<IPaymentPublisher>();

            var mapper = new Mapper(mapperConfig);
            var id = Guid.NewGuid();

            var payment = new MerchantPayment()
            {
                Id = id,
                Amount = 9.99,
                Currency = "USD",
                MerchantId = "1",
                PaymentMethod = new PaymentMethod
                {
                    Cvv = "123",
                    ExpirationMonth = "05",
                    ExpirationYear = "2021",
                    Number = "4319487612345678",
                    PaymentMethodId = new Guid(),
                    Type = "Visa"
                },
                Status = Status.Submitted

            };

            //Act
            paymentRepo.Setup(x => x.GetById(id)).Returns(Task.FromResult(payment));
            var controller = new PaymentController(paymentRepo.Object, mapper, paymentPublisher.Object);

            var result = controller.GetPayment(id);
            var value = ((OkObjectResult)result.Result).Value as MerchantPaymentResponse;

            //Assert
            Assert.That(value.Number, Is.EqualTo("XXXXXXXXXXXX5678"));

        }
    }
}
