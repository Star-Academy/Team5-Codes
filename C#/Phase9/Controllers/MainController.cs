using Microsoft.AspNetCore.Mvc;
using Nest;
using Phase8;

namespace Phase9.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class MainController : ControllerBase
    {

        [HttpGet]
        public string Get([FromQuery] string query)
        {
            var items = Phase8.Program.ReadItemsFromFile<Person>();
            var response = Phase8.Program.GenerateResponse(new string[] { query }, items);
            return $"The query: {response.Documents}";
        }


    }
}
