using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using Orleans;
using SimpleOrleansSample.Interfaces;

namespace SimpleOrleansSample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DemoController : ControllerBase
    {
        private readonly ILogger<DemoController> _logger;
        private readonly IGrainFactory _grainFactory;

        public DemoController(ILogger<DemoController> logger, IGrainFactory grainFactory)
        {
            _logger = logger;
            _grainFactory = grainFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var demoGrain = _grainFactory.GetGrain<IDemoGrain>("demo");
            var randomNumber = await demoGrain.GetRandomNumber();

            return Ok(randomNumber);
        }
    }
}
