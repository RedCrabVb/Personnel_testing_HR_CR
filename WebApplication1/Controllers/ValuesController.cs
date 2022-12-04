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
            result.IdTest = resultUserDTO.IdTest;
            result.Date = DateTime.Now.ToLongDateString();
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

            result.Title = test.Title;
            test.Questions = questions;
            result.QuestionsResult = new List<QuestionResult>();

            foreach (var q in questions)
            {
                var nqr = new QuestionResult();
                nqr.AnswerQ = resultUserDTO.QuestionsResult.Find(x => x.QuestionID == q.QuestionID).AnswerQ;
                nqr.AnswerUser = q.AnswerQ;
                nqr.QuestionText = q.QuestionText;
                nqr.Comment = q.Comment != null ? q.Comment : "";
                nqr.Answers = new List<AnswerResult>();

                foreach (var qa in q.Answers)
                {
                    var qar = new AnswerResult();
                    qar.Title = qa.Title;
                    nqr.Answers.Add(qar);
                }
                result.QuestionsResult.Add(nqr);
            }

            _ctx.SaveChanges();

            return result;
        }

        [HttpPost("testAdd")]
        [ActionName("testAdd")]
        public TestEntity TestAdd(Data.Entity.TestEntity testEntityDict)
        {
            Console.WriteLine(testEntityDict);
            var result = _ctx.Tests.Add(testEntityDict).Entity;
            _ctx.SaveChanges();

            return result;
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
