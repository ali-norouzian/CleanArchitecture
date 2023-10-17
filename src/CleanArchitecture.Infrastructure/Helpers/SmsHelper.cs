using Infrastructure.Exceptions;
using Infrastructure.Settings;
using Microsoft.Extensions.Options;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class SmsHelper
    {
        private readonly SmsSetting _setting;



        public SmsHelper(IOptions<SmsSetting> setting)
        {
            _setting = setting.Value;

        }

        public async Task SendSms(string template, string phoneNumber, string param1 = "", string param2 = "", string param3 = "")

        {

            var apiUrl = _setting.ApiUrl;
            var apiKey = _setting.ApiKey;
            var type = _setting.Type;



            var client = new RestClient(apiUrl);
            var request = new RestRequest(apiUrl, Method.Post);
            request.AddHeader("apikey", apiKey);
            request.AddParameter("type", type);
            request.AddParameter("receptor", phoneNumber);
            request.AddParameter("template", template);
            request.AddParameter("param1", param1);
            request.AddParameter("param2", param2);
            request.AddParameter("param3", param3);
            var response = client.Execute(request);

            if (!response.IsSuccessful)
                throw new BusinessLogicException("هنگام ارسال پیامک خطایی رخ داد");


        }
    }
}
