using Carter;
using Microsoft.AspNetCore.Http;

namespace SampleApi
{
    public class SampleModule : CarterModule
    {
        public SampleModule()
        {
            Get("/Sample", async (request, response) =>
            {
                await response.WriteAsync("SampleResponse");
            });
        }
    }
}
