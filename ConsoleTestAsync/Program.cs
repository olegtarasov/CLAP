using System;
using System.Threading.Tasks;
using CLAP;

namespace ConsoleTestAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Parser<App>().RunAsync(args, new App());
        }
    }

    public class App
    {
        [Verb]
        public async Task Hello()
        {
            Console.WriteLine("Waiting 3 sec");
            await Task.Delay(3000);
            Console.WriteLine("Done");
        }
    }
}