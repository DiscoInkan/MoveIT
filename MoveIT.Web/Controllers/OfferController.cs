using Microsoft.AspNetCore.Mvc;

namespace MoveIT.Web.Controllers
{
    [ApiController]
    [Route("api")]
    public class OfferController : ControllerBase
    {

        private readonly ILogger<OfferController> _logger;

        public OfferController(ILogger<OfferController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

    }
}