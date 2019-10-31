using Microsoft.Extensions.Configuration;

namespace Pluralsight.Services
{
    internal class Greeting : IGreeting
    {
        private readonly IConfiguration configuration;

        public Greeting(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public string GetMessageOfDay()
        {
            return configuration["Greeting"];
        }
    }
}