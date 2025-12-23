using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPreJoinerB2.Controllers.Data_1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new {Message="My data 1"});
        }
    }
}
