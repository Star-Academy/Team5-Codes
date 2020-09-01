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
        public string Get([FromBody] string[] query)
        {
            var items = App.ReadItemsFromFile<Person>();
            var response = App.GenerateResponse(query, items);
            return TakeOutput(response);
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
