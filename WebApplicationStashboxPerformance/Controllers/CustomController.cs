using ClassLibrary1;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace WebApplicationStashboxPerformance.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class CustomController : ControllerBase
    {
        private readonly IEnumerable<IMarker> markers;
        private readonly TimeSpan elapsedTime;

        public CustomController(IServiceProvider serviceProvider)
        {
            var stopWatch = new Stopwatch();

            stopWatch.Start();
            markers = serviceProvider.GetServices<IMarker>();
            elapsedTime = stopWatch.Elapsed;
        }

        [HttpGet]
        public Result Count()
        {
            return new Result { Count = markers.Count(), Elapsed = elapsedTime };
        }
    }
}
