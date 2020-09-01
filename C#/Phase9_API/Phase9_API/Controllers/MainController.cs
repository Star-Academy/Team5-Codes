using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Nest;
using Phase8;
using System.Text;

namespace Phase9.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class MainController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get([FromBody] string[] query)
        {
            var items = App.ReadItemsFromFile<Person>();
            var response = App.GenerateResponse(query, items);
            return Ok(TakeOutput(response));
        }

        private string TakeOutput(ISearchResponse<Person> response)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in response.Documents)
                stringBuilder.Append(item.ToString() + '\n');
            return stringBuilder.ToString();
        }


    }
}
