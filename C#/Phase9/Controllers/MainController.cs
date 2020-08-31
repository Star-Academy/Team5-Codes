using Microsoft.AspNetCore.Mvc;

namespace Phase9.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public string Get([FromQuery] string query)
        {
            return $"The query: {query}";
        }
    }
}
