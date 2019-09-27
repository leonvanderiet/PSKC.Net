using Microsoft.Extensions.Configuration;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace PSKC.Net.ConsoleApp
{
    class Program
    {
        private static void Main(string[] args)
        {
            IServiceCollection services = new ServiceCollection();
            services.AddTransient<App>();
            var serviceProvider = services.BuildServiceProvider();
            var app = serviceProvider.GetService<App>();
            app.Run(args);
        }
    }
}
