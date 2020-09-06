using Microsoft.AspNetCore.Mvc;
using Nest;
using Phase8;
using Phase8.Modules;
using System;
using System.Text;

namespace Phase9.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class MainController : ControllerBase
    {
        [HttpPost]
        public IActionResult Get([FromBody] string text)
        {
            QuerySample query = new QuerySample(text);
            var searchEngine = new Phase8.Nest.SearchEngine();
            var response = searchEngine.GenerateResponse(query);
            return Ok(TakeOutput(response) + query.Text);
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
