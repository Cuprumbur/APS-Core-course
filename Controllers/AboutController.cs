using Microsoft.AspNetCore.Mvc;

namespace Pluralsight.Controllers
{
    [Route("company/[controller]/[action]")]
    public class AboutController
    {
        [Route("")]
        public string Phone()
        {
            return "1+555+555";
        }
        [Route("[action]")]

        public string Address()
        {
            return "USA";
        }
    }
}