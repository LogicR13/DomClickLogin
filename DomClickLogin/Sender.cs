using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DomClickLogin
{
    class Sender
    {
        private static CookieContainer _cookies;
        public string URL {get; set;}

        public Sender()
        {
            _cookies = new CookieContainer();
        }

        public async Task<string> Request(MultipartFormDataContent formData, string method)
        {
            HttpClientHandler httpClientHandler = new()
            {
                CookieContainer = _cookies,
                UseCookies = true
            };

            HttpClient client = new(httpClientHandler);
            
            client.DefaultRequestHeaders.Add("Accetp-Encoding", "gzip,deflate,br");
            client.DefaultRequestHeaders.Add("Accetp-Encoding", "ru-RU,ru;q0.5");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
            client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/88.0.4324.182 Safari/537.36 Edg/88.0.705.81");

            try
            {
                HttpResponseMessage response;

                if(method == "POST")
                {
                    response = await client.PostAsync(URL, formData);
                    return response.ToString();
                }                     
                else
                    return await client.GetStringAsync(URL);

                
            } catch (Exception ex)
            {
                return ex.Message;
            }
        }

        public static CookieContainer GetCookie()
        {
            return _cookies;
        }
    }
}
