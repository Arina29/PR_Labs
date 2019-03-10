using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Lab3
{
    class Program
    {


        static void Main(string[] args)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://httpbin.org");
                Console.WriteLine("==============================Get Method========================");
                Get(client);
                Console.WriteLine("==============================Put Method========================");
                Put(client);
                Console.WriteLine("=============================Post Method========================");
                Post(client);
                Console.WriteLine("============================Patch Method========================");
                Patch(client);
                Console.WriteLine("===========================Delete Method========================");
                Delete(client);
            }

            Console.ReadKey();
        }

        static void Get(HttpClient client)
        {
            var response = client.GetStringAsync("/response-headers").Result;
            Console.WriteLine(response);
        }

        static void Put(HttpClient client)
        {
            var httpContent = new StringContent("{ \"MethodName\": \"Put\" }", Encoding.UTF8, "application/json");
            var result = client.PutAsync("/anything", httpContent).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        static void Post(HttpClient client)
        {
            var httpContent = new StringContent("{ \"MethodName\": \"Post\" }", Encoding.UTF8, "application/json");
            var result = client.PostAsync("/post", httpContent).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);

        }

        static void Patch(HttpClient client)
        {
            var request = new HttpRequestMessage(new HttpMethod("PATCH"), client.BaseAddress + "/patch");
            var result =  client.SendAsync(request).Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }

        static void Delete(HttpClient client)
        {
            var result = client.DeleteAsync("/delete").Result.Content.ReadAsStringAsync().Result;
            Console.WriteLine(result);
        }
    }
}
