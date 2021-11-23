using System;
using NBomber.CSharp;
using NBomber.Contracts;

namespace LoadAndPenetrationTestingWithNbomber
{
    class Program
    {
        static void Main(string[] args)
        {
            var httpFactory = NBomber.Plugins.Http.CSharp.HttpClientFactory.Create();

            var step = Step.Create("step", clientFactory: httpFactory, async context =>
           {
               var response = await context.Client.GetAsync("http://localhost:5000/Sample", context.CancellationToken);

               return response.IsSuccessStatusCode ? Response.Ok(statusCode: (int)response.StatusCode)
               : Response.Fail(statusCode: (int)response.StatusCode);
           });

            var scenario = ScenarioBuilder
                .CreateScenario("simple_http", step)
                .WithWarmUpDuration(TimeSpan.FromSeconds(10))
                .WithLoadSimulations(Simulation.InjectPerSec(100, TimeSpan.FromSeconds(20)));

            NBomberRunner.RegisterScenarios(scenario).Run();
        }
    }
}
