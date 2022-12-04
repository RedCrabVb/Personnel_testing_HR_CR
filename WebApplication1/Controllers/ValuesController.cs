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
        private readonly ApplicationDbContext _ctx;

        public ValuesController(ApplicationDbContext context)
        {
            _ctx = context;
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
        public ResultTest UpdateQuestion(ResultUserDTO resultUserDTO)
        {
            var result = new ResultTest();
            result.Fullname = resultUserDTO.Fullname;
            result.Id = resultUserDTO.IdTest;
            var test = _ctx.Tests.Where(x => x.Id == resultUserDTO.IdTest).Include(x => x.Questions).First();
            var questionsId = _ctx.Tests.Where(x => x.Id == resultUserDTO.IdTest).Include(x => x.Questions).First();
            var questions = _ctx.Questions.Where(q => questionsId.Questions.Contains(q)).Select(q => new Question
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
            
            test.Questions = questions;
            result.QuestionsResult = new List<QuestionResult>();

            foreach (var q in questions)
            {
                var nqr = new QuestionResult();
                nqr.AnswerQ = q.AnswerQ;
                nqr.QuestionText = q.QuestionText;
                nqr.Comment = q.Comment;
                nqr.Answers = q.Answers;
                result.QuestionsResult.Add(nqr);
            }
            
            //foreach (var q in resultUserDTO.QuestionsResult)
            //{
            //    Predicate<Question> match = rq => rq.QuestionID == q.QuestionID;
            //    var qResult = result.QuestionsResult.Find(match);
            //    qResult.AnswerQ = q.AnswerQ;
            //    qResult.QuestionID = 0;
            //}

            _ctx.ResultTests.Add(result);
            _ctx.SaveChanges();

            return result;
        }

        [HttpPost("testAdd")]///app/Values/testAdd
        [ActionName("testAdd")]
        public async Task<ActionResult<string>> TestAdd(Data.Entity.TestEntity testEntityDict)
        {
            //var dict = DeserializeForm(input);
            Console.WriteLine(testEntityDict);
            _ctx.Tests.Add(testEntityDict);
            _ctx.SaveChanges();

            return testEntityDict.ToString();
        }

        [HttpGet("currentTest")]
        public TestEntity GetTest(int id)
        {

            var test = _ctx.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

            return test;

        }

        [HttpGet("allTest")]
        public List<TestEntity> GetTests()
        {

            var tests = _ctx.Tests.ToList();

            return tests;
        }

        [HttpGet("allQuestions")]
        public List<Question> GetQuestions(int id)
        {

            var questionsId = _ctx.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

            return _ctx.Questions.Where(q => questionsId.Questions.Contains(q)).Select(q => new Question
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
