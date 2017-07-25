using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    class Program 
    {
        static HttpClient client = new HttpClient();

        static void ShowMessage(HelloWorld msg)
        {
            Console.WriteLine($"Message: " + msg.Message);
        }
       
        static void Main(string[] args)
        {
            RunAsync().Wait();
        }

        static async Task<HelloWorld> GetMessageAsync(string path)
        {
            HelloWorld msg = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
               var HelloWorldJsonString = await response.Content.ReadAsStringAsync();
                msg = JsonConvert.DeserializeObject<HelloWorld>(HelloWorldJsonString);
                        
            }
            return msg;
        }

        static async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:50631/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                HelloWorld msg = await GetMessageAsync("api/HelloWorld/1");
                ShowMessage(msg);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }

    }
}
