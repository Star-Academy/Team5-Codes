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
        public IActionResult GetSearchResult([FromBody] string[] query)
        {
            var items = App.ReadItemsFromFile<Person>();
            var response = App.GenerateResponse(query, items);
            return Ok(CreateResponse(response));
        }

        private string CreateResponse(ISearchResponse<Person> response)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in response.Documents)
                stringBuilder.Append(item.ToString() + '\n');
            return stringBuilder.ToString();
        }


    }
}
