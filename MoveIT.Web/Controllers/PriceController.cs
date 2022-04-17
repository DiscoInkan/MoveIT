using Microsoft.AspNetCore.Mvc;
using MoveIT.Web.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MoveIT.Web.Controllers
{
    [Route("api/price")]
    [ApiController]
    public class PriceController : ControllerBase
    {

        // POST api/price
        [HttpPost]
        public string FetchPrice([FromBody] Price price)
        {
            return price.LivingSpace.ToString();
        }

    }
}
