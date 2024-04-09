
using RestSharp;
using System.Threading.Tasks;

namespace Common.Infrastructure.Services.SMS
{
    public class SmsSender : ISmsSender
    {
        //راز پیامک

        public async Task<bool> SendVertificateCode(string receptor, string sender, string text)
        {

            var client = new RestSharp.RestClient("https://rest.payamak-panel.com");
            var smsData = new SendSmsData();
            var request = new RestRequest("/api/SendSMS/SendSMS", Method.Post);
            request.AddHeader("content-type", "application/x-www-form-urlencoded");
            request.AddHeader("postman-token", "fcddb5f4-dc58-c7d5-4bf9-9748710f8789");
            request.AddHeader("cache-control", "no-cache");
            request.AddParameter("application/x-www-form-urlencoded", $"username={smsData.Username}&password={smsData.Password}&to={receptor}&from={sender}&text={text}&isflash=false", ParameterType.RequestBody);
            var response = client.Execute(request);
            if (response.IsSuccessful)
            {
                return true;
            }
            return false;
        }


    }
}
