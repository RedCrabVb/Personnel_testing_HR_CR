using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Primitives;
using Personnel_testing_HR_CR.Data.DTO;

namespace Personnel_testing_HR_CR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static Dictionary<string, StringValues> DeserializeForm(string content)
        {
            using var reader = new FormReader(content);
            return reader.ReadForm();
        }


        [HttpGet("test/{xid}")]
        public async Task<ActionResult<string>> Create(string xid)
        {
            return new ObjectResult(xid);
        }

        [HttpPost("question")]
        public async Task<ActionResult<string>> UpdateQuestion(Question[] question)
        {
            return new ObjectResult(question[0].AnswerQ);
        }

        [HttpPost("testAdd")]///app/Values/testAdd
        [ActionName("testAdd")]
        public async Task<ActionResult<string>> TestAdd([FromBody] string input)
        {
            //var dict = DeserializeForm(input);
            Console.WriteLine(input);

            return new ObjectResult(input);
        }

    }
}
