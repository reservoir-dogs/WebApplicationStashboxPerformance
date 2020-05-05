using ClassLibrary1;

using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;

namespace WebApplicationStashboxPerformance.Controllers
{

    [Route("api/[controller]s")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly IList<IMarker> markers;

        public DefaultController(IList<IMarker> markers)
        {
            this.markers = markers;
        }

        [HttpGet]
        public int Count()
        {
            return markers.Count;
        }
    }
}
