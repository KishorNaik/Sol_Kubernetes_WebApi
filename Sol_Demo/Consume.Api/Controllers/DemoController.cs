using Consume.Api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Consume.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/demo")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        private readonly IProducerService producerService = null;

        public DemoController(IProducerService producerService)
        {
            this.producerService = producerService;
        }

        [HttpGet("consume")]
        public async Task<IActionResult> Consume()
        {
            var data = await producerService.GetDataAsync();

            return base.Ok(data);
        }
    }
}