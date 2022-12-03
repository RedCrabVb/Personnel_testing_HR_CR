using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data.DTO;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
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
    }
}
