using Json;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using Personnel_testing_HR_CR.Data;
using Personnel_testing_HR_CR.Data.DTO;
using Personnel_testing_HR_CR.Data.Entity;

namespace Personnel_testing_HR_CR.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ValuesController(ApplicationDbContext context)
        {
            _context = context;
        }

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
        public async Task<ActionResult<string>> UpdateQuestion(QuestionDTO[] question)
        {
            return new ObjectResult(question[0].AnswerQ);
        }

        [HttpPost("testAdd")]///app/Values/testAdd
        [ActionName("testAdd")]
        public async Task<ActionResult<string>> TestAdd(Data.Entity.TestEntity testEntityDict)
        {
            //var dict = DeserializeForm(input);
            Console.WriteLine(testEntityDict);
            _context.Tests.Add(testEntityDict);
            _context.SaveChanges();

            return testEntityDict.ToString();
        }

        [HttpGet("currentTest")]
        public TestEntity GetTest(int id)
        {

            var test = _context.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

            return test;

        }

        [HttpGet("allTest")]
        public List<TestEntity> GetTests()
        {

            var tests = _context.Tests.ToList();

            return tests;
        }

        [HttpGet("allQuestions")]
        public List<Question> GetQuestions(int id)
        {

            var questionsId = _context.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

            return _context.Questions.Where(q => questionsId.Questions.Contains(q)).Select(q => new Question
            {
                QuestionID = q.QuestionID,
                QuestionText = q.QuestionText,
                AnswerQ = q.AnswerQ,
                Answers = q.Answers.Select(c => new Answer
                {
                    Id = c.Id,
                    Title = c.Title
                }).ToList()

            }).ToList();

        }
    }
}
