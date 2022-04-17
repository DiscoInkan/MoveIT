using Microsoft.AspNetCore.Mvc;
using MoveIT.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoveIT.Web.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController : ControllerBase
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly IConfiguration _config;

        public PriceController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _clientFactory = httpClientFactory; 
            _config = configuration;    
        }      

        // POST api/price
        [HttpPost]
        public async Task<ActionResult<string>> FetchPrice([FromBody] Price price)
        {
            var client = _clientFactory.CreateClient();
            var calculatePriceUri = _config.GetValue<string>("PriceFunctionUrl");
            var response = await client.PostAsJsonAsync(calculatePriceUri, price);
            if (response.IsSuccessStatusCode)
            {
                string respContent = response.Content.ReadAsStringAsync().Result;
                return respContent;
            }
            return BadRequest();
        }

    }
}
