using System;
using System.Threading;
using System.Threading.Tasks;
using CLAP;
using Microsoft.Extensions.DependencyInjection;

namespace ConsoleTestAsync
{
    class Program
    {
        static async Task Main(string[] args)
        {
            await new Parser<App>().RunAsync(args, new App());
            Console.WriteLine("Outer scope");
        }
    }

    public class App
    {
        [Verb]
        public async Task Hello([Inject] IFoo foo)
        {
            Console.WriteLine("Waiting 3 sec");
            await Task.Delay(3000);
            Console.WriteLine("Done");
            foo.Hello();
        }

        [Verb]
        public void Sync([Inject] IFoo foo)
        {
            Console.WriteLine("I am a sync method in async context!");
            Thread.Sleep(3000);
            Console.WriteLine("Done");
            foo.Hello();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IFoo, Foo>();
        }
    }

    public interface IFoo
    {
        void Hello();
    }

    public class Foo : IFoo
    {
        public void Hello()
        {
            Console.WriteLine("Hello from Foo!");
        }
    }
}