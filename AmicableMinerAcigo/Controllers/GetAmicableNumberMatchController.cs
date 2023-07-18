using Microsoft.AspNetCore.Mvc;
using System;

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

        [HttpGet(Name = "GetAmicableNumberMatch")]
        public string[] GetAmicableNumberMatch()
        {

            string[] Summaries = new[] { "", "" };

            //            32 TeRiele 1990
            //iSecondCalculatedLastNum = 10020507332 = 2 ^ 2 * 11 * 31 * 61 * 83(iFirstCalculatedLastNum) * 1451
            //iLastNum = 10306191676 = 2 ^ 2 * 11 * 31 * 1693 * 4463 = iCountFor(1)

            //            32 TeRiele 1990
            //10020507332 = 2 ^ 2 * 11 * 31 * 61 * 83 * 1451
            //10306191676 = 2 ^ 2 * 11 * 31 * 1693 * 4463


            //            23 Poulet 1929
            //iSecondCalculatedLastNum = 38453967088 = 2 ^ 4 * 17 * 141374879
            //iLastNum = 40433215952 = 2 ^ 4 * 179 * 743 * 19001


            Int128 iLastNum = 0;

            Int128 iBase = 4463;
            iLastNum = 10306191676;

            int iExponentElevated = 2;
            Int128 iMinoPair = iBase;
            Int128 iFirstCalculatedLastNum = iExponentElevated * 2 * 11 * 31 * 61 * 83;
            Int128 iSecondCalculatedLastNum = iExponentElevated ^ iFirstCalculatedLastNum * iBase; // 4463 = iCountFor(1)
            Int128 iCountFor = iBase;
            Int128 iCounter = 0;




            //            X44 Walker&Einstein 2001
            //5480828320492525 = 5 ^ 2 * 7 ^ 2 * 11 * 13 * 19 * 31 * 17 * 23 * 103 * 1319
            //5786392931193875 = 5 ^ 3 * 7 * 11 * 13 * 19 * 31 * 37 * 43 * 61 * 809
            //github.com/SChernykh/Amicable




            for (iCountFor = iBase; iCountFor < iLastNum; iCountFor++)
            {
                iBase++;
                iCounter++;
                if (iLastNum % iCountFor == 0)
                {
                    iMinoPair = iMinoPair + iCountFor;
                }
            }
            iSecondCalculatedLastNum = iExponentElevated ^ iFirstCalculatedLastNum * iBase;


            if (iLastNum == iCountFor && iLastNum == iBase)
            {
                Summaries = new[]
                    {
                        "\"They are a Pair of Amicable Numbers\"",
                        "LastNum:" + iLastNum + " iCountFor: " + iCountFor + " iSecondCalculatedLastNum: " + iSecondCalculatedLastNum + " iBase: " + iBase + " Minor Pair: " + iMinoPair + " iFirstCalculatedLastNum: " + iFirstCalculatedLastNum + " iCounter: " + iCounter
                    };
            }
            else
            {
                Summaries = new[]
                    {
                        "\"They are not Amicable Numbers\"",
                        "LastNum:" + iLastNum + " iCountFor: " + iCountFor + " iSecondCalculatedLastNum: " + iSecondCalculatedLastNum + " iBase: " + iBase + " Minor Pair: " + iMinoPair + " iFirstCalculatedLastNum: " + iFirstCalculatedLastNum + " iCounter: " + iCounter
                    };
            }

            return Summaries;
        }
    }
}