using Microsoft.AspNetCore.Mvc;

namespace AmicableMinerAcigo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetAmicableNumberMatchController : ControllerBase
    {
        private readonly ILogger<GetAmicableNumberMatchController> _logger;

        public GetAmicableNumberMatchController(ILogger<GetAmicableNumberMatchController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetAmicableNumberMatch/{num1:long?}/{num2:long?}")]
        public string[] GetAmicableNumberMatch(long? num1 = 0, long? num2 = 0, long? sum1 = 0, long? sum2 = 0)
        {
            string[] Summaries = new[]
{
        "",
        ""
        };
            Summaries = new[]
        {
        "\"Infom First number in URL parameter (num1=0)\"",
        "\"Infom Second number in URL parameter (num1=0)\""
        };

            long i;
            for (i = 1; i < num1; i++)
            {
                if (num1 % i == 0)
                {
                    sum1 = sum1 + i;
                }
            }
            for (i = 1; i < num2; i++)
            {
                if (num2 % i == 0)
                {
                    sum2 = sum2 + i;
                }
            }
            if (num1 == sum2 && num2 == sum1)
            {
                Summaries = new[]
                    {
                        "\"They are a Pair of Amicable Numbers\"",
                        ""
                    };
            }
            else
            {
                Summaries = new[]
                    {
                        "\"They are not Amicable Numbers\"",
                        ""
                    };
            }
            return Summaries;
        }
    }
}