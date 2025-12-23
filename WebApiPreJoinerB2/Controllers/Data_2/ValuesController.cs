using Asp.Versioning;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApiPreJoinerB2.Controllers.Data_2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ValuesController : ControllerBase
    {

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(new { Message = "My data 2" });
        }
    }
}
