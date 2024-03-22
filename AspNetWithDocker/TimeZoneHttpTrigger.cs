using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using System.Runtime.InteropServices;

namespace Net8SimpleHttpTrigger
{
    public sealed class TimeZoneHttpTrigger
    {
        [Function("TimeZone")]
        public IActionResult GetTimeZone([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post")] HttpRequest req)
        {
            return new OkObjectResult(new
            {
                RuntimeInformation.FrameworkDescription,
                RuntimeInformation.OSDescription,
                TimeZone1 = TimeZoneInfo.FindSystemTimeZoneById("Pacific Standard Time"),
                TimeZone2 = TimeZoneInfo.FindSystemTimeZoneById("Tokyo Standard Time")
            });
        }
    }
}
