using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.Net.Http;

namespace netcoreVote
{
    public class Program
    {
        private static Timer timer;
        public void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            timer = new Timer(_ => OnCallBack(), null, 1000 * 2, Timeout.Infinite);

            Console.ReadLine();
        }

        private async void OnCallBack()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Cache-Control", "no-cache");
            var json = await client.GetStringAsync(new Uri("http://ppedv.de/msts/votes.json"));
            Console.WriteLine(json);
            timer.Change(1000, 1000 * 2);
        }
    }
}
