using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using PaymentGateway.Libs.Models;

namespace PaymentGateway.Libs.Services
{
    public class FakeBankInitiatePaymentRequest : IInitiatePayment
    {
        //ToDo - consider replacing with IHttpClient DI - free Polly extensions and fixes socket exceptions issues
        private static readonly HttpClient Client = new HttpClient();

        public async Task<BankResponse> InitiatePaymentWithCardDetails(MerchantPayment payment)
        {
            var json = JsonConvert.SerializeObject(payment);

            var url = "http://fakebank:8080/payment-initiation"; //ToDo - add to config
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await Client.PostAsync(url, content);

            var responseString = await response.Content.ReadAsStringAsync();

            var responseJson = JsonConvert.DeserializeObject<BankResponse>(responseString);

            return responseJson;

        }

    }



}
