using Microsoft.AspNetCore.Mvc;
using Nest;
using Phase8;
using Phase8.Modules;
using Phase8.Nest;
using System;
using System.Text;

namespace Phase9.Controllers
{
    [ApiController]
    [Route("[Controller]/[Action]")]
    public class MainController : ControllerBase
    {
        private readonly ISearchEngine searchEngine;

        public MainController(ISearchEngine searchEngine)
        {
            this.searchEngine = searchEngine;
        }

        [HttpPost]
        public IActionResult Get([FromBody] string text)
        {
            QuerySample query = new QuerySample(text);
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
