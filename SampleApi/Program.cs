using Carter;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;

namespace SampleApi
{
    class Program
    {
        static void Main(string[] args)
        {
            var webHost = new WebHostBuilder()
               .UseKestrel()
               .ConfigureServices(services =>
               {
                   services.AddCarter();
               })
               .Configure(app =>
               {
                   app.UseRouting();
                   app.UseEndpoints(builder => builder.MapCarter());
               })
               .Build();
            webHost.Run();
        }
    }
}
