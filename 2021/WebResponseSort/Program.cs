using System;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Linq;
namespace WebResponseSort
{
    class Program
    {
        static void Main(string[] args)
        {
            var usrInp = ReadInput();
            string url = $"{usrInp.url}:{usrInp.port}/?a={usrInp.a}&b={usrInp.b}";

            string response;
            using (Stream stream = WebRequest.Create(url).GetResponse().GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    response = reader.ReadToEnd();
                }
            }

            var data = JsonSerializer.Deserialize<int[]>(response);
            foreach (int num in data.Where(x => x >= 0).OrderByDescending(x => x))
            {
                Console.WriteLine(num);
            }
        }


        static (string url, int port, int a, int b) ReadInput()
         => (url: Console.ReadLine(),
            port: Convert.ToInt32(Console.ReadLine()),
            a: Convert.ToInt32(Console.ReadLine()),
            b: Convert.ToInt32(Console.ReadLine()));
    }
}
