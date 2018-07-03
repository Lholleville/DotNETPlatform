using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Net.Http;

namespace Swagger_Spammer
{
    class Program
    {

        public static async Task<string> SpamdatDataAsync(int id, String name, String myMac, int type, int myNoV, String DataValue)
        {
            // notre cible
            string page = "http://localhost:50227/api/v1/Devices";

            string json = new JavaScriptSerializer().Serialize(new
            {
                IdDevice = id,
                Mac = myMac,
                Name = name,
                Type = type,
                NoV = myNoV,
                Value = DataValue,
                Old = 0
            });

            using (HttpClient client = new HttpClient())
            {
                HttpContent contentPost = new StringContent(json,
                Encoding.UTF8, "application/json");

                var response = await client.PostAsync(new Uri(page), contentPost)
                      .ContinueWith(
                         (t) => t.Result.EnsureSuccessStatusCode()
                       );
            }

            return json;
        }

        public static async Task<string> SpamDataAsync(int id, String name, String myMac, int type, int myNoV, String DataValue)
        {
            // notre cible
            string page = "http://localhost:50227/api/v1/Devices";
            var result = "";
            string json = new JavaScriptSerializer().Serialize(new
            {
                IdDevice = id,
                Mac = myMac,
                Name = name,
                Type = type,
                NoV = myNoV,
                Value = DataValue,
                Old = 0
            });
            using (HttpClient client = new HttpClient())
            {
                HttpContent contentPut = new StringContent(json,
                Encoding.UTF8, "application/json");

                var response = await client.PutAsync(new Uri(page), contentPut)
                      .ContinueWith((t) => t.Result.EnsureSuccessStatusCode());
                result = response.ToString();
            }

            return result;
        }

        static void Main(string[] args)
        {
            String[] Names = { "Bidule", "Machin", "Truc", "Fourbi", "Chose", "Engin", "Bazar", "Affaire", "iTruc", "iBidule" };
            String[] Mac = { "5E:FF:56:A2:AF:15", "D9:FF:56:A5:C5:C4", "C7:CC:56:B1:GA:87", "F3:FF:G6:T5:A5:C7", "A3:AA:G6:T5:A5:S4", "G3:FF:G6:T5:A5:C8", "D1:AA:G1:T2:A9:S6", "E3:BB:G6:T5:A5:E5", "C4:CC:G6:T5:A5:C7", "G3:FF:G6:T5:A5:P8" };
            Random rnd = new Random();
            System.Threading.Thread.Sleep(1500);
            for (int i = 0; i < Names.Count(); i++)
            {
                Console.WriteLine((i + 1) + " " + Names[i] + " " + Mac[i] + "\n");

                SpamdatDataAsync(i + 1, Names[i], Mac[i], i + 1, 1, rnd.Next(1, 500).ToString());
                System.Threading.Thread.Sleep(1500);
            }
            Console.WriteLine("OK Spamming the data stream || Press escape to end the loop ");

            while (true)
            {
                for (int i = 0; i < Names.Count(); i++)
                {
                    System.Threading.Thread.Sleep(100);

                    Console.WriteLine((i + 1) + " " + Names[i] + " " + Mac[i] + "\n");

                    var result = SpamDataAsync(i + 1, Names[i], Mac[i], i + 1, 1, rnd.Next(1, 500).ToString());
                    if (i == Names.Count() - 1)
                    {
                        System.Threading.Thread.Sleep(500);
                    }
                }
            }
            Console.Read();
        }
    }
}
