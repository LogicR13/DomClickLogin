using System;
using System.Net;
using System.Net.Http;

namespace DomClickLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            HttpContent login = new StringContent("79255147533");
            HttpContent pasword = new StringContent("яшз07щз9");

            var formData = new MultipartFormDataContent();
            formData.Add(login);
            formData.Add(pasword);

            Sender sender = new Sender();
            string response;
            
            sender.URL = "https://domclick.ru/cas/login";
            response = sender.Request(formData, "POST").Result;  
            Console.WriteLine(response);

            CookieContainer cookie = Sender.GetCookie();

            Console.WriteLine("---------------------");

            foreach (var c in cookie.GetCookies(new Uri("https://domclick.ru/cas/login")))
            {
                Console.WriteLine(c);
            }

           /* sender.URL = "https://domclick.ru/";
            response = sender.Request(null, "GET").Result;

            Console.WriteLine(response);*/

            Console.ReadKey();
        }
    }
}
