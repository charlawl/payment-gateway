using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public class InitiatePayment : IInitiatePayment
    {
        //consider replacing with IHttpClient DI - free Polly extensions and fixes socket exceptions issues
        private static readonly HttpClient Client = new HttpClient();

        public async Task<BankResponse> InitiatePaymentWithCardDetails(MerchantPaymentRequest paymentRequest)
        {
            var json = JsonConvert.SerializeObject(paymentRequest);

            var url = "http://localhost:8080/payment-initiation";
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseJson = JsonConvert.DeserializeObject<BankResponse>(responseString);

            return responseJson;

        }

        private HttpRequestMessage BuildRequestMessage()
        {
            return null;
        }

    }


    public interface IInitiatePayment
    {
        Task<BankResponse> InitiatePaymentWithCardDetails(MerchantPaymentRequest paymentRequest);
    }
}
