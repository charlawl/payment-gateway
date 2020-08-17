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
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

            

        }

        [Test]
        public void ReturnCreatedActionResult()
        {
            //Arrange
            var paymentRepo = new Mock<IPaymentRepository>();
            var profile = new MerchantPaymentProfile();
            var mapperConfig = new MapperConfiguration(x=> x.AddProfile(profile));
            var paymentPublisher = new Mock<IPaymentPublisher>();

            var mapper = new Mapper(mapperConfig);

            var paymentRequest = new MerchantPaymentRequest
            {
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
                }
            };


            var controller = new PaymentController(paymentRepo.Object, mapper, paymentPublisher.Object);

            //Act
            var result = controller.SubmitPayment(paymentRequest);

            //Assert
            Assert.That(result.Result, Is.TypeOf<CreatedAtActionResult>());
        }

        [Test]
        public void ReturnCorrectValuesInResponse()
        {
            //Arrange
            var paymentRepo = new Mock<IPaymentRepository>();
            var profile = new MerchantPaymentProfile();
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(profile));
            var paymentPublisher = new Mock<IPaymentPublisher>();

            var mapper = new Mapper(mapperConfig);

            var paymentRequest = new MerchantPaymentRequest
            {
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
                }
            };


            var controller = new PaymentController(paymentRepo.Object, mapper, paymentPublisher.Object);

            //Act
            var result = controller.SubmitPayment(paymentRequest);
            var value = ((CreatedAtActionResult)result.Result).Value as MerchantPaymentResponse;  //https://github.com/dotnet/AspNetCore.Docs/issues/12533 - ew.

            //Assert
            Assert.That(value.Amount, Is.EqualTo(9.99));
            Assert.That(value.Currency, Is.EqualTo("USD"));
            Assert.That(value.MerchantId, Is.EqualTo("1"));

        }

        [Test]
        public void StatusIsSetToADefaultStateOfSubmittedWhenRequestIsMadeByMerchant()
        {
            //Arrange
            var paymentRepo = new Mock<IPaymentRepository>();
            var profile = new MerchantPaymentProfile();
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(profile));
            var paymentPublisher = new Mock<IPaymentPublisher>();

            var mapper = new Mapper(mapperConfig);

            var paymentRequest = new MerchantPaymentRequest
            {
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
                }
            };


            var controller = new PaymentController(paymentRepo.Object, mapper, paymentPublisher.Object);

            //Act
            var result = controller.SubmitPayment(paymentRequest);
            var value = ((CreatedAtActionResult)result.Result).Value as MerchantPaymentResponse;

            //Assert
            Assert.That(value.Status, Is.EqualTo(Status.Submitted));
            Assert.That(value.Status, Is.Not.EqualTo(Status.Declined));

        }
    }
}