using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Personnel_testing_HR_CR.Data;
using Personnel_testing_HR_CR.Data.Entity;

namespace Personnel_testing_HR_CR.Pages
{
    public class TestAllViewModel : PageModel
    {
        public List<TestEntity> testEntitys { get; set; }
        public TestEntity currentTest { get; set; }
        private readonly ILogger<PassingTestsModel> _logger;
        public ApplicationDbContext _ctx;

        public TestAllViewModel(ILogger<PassingTestsModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _ctx = context;
        }


        public void OnGet()
        {
            testEntitys = new List<TestEntity>();
            var tests = _ctx.Tests.Include(x => x.Questions).ToList();

            foreach (var test in tests)
            {
                var questionsId = _ctx.Tests.Include(x => x.Questions).First();

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

                testEntitys.Add(test);
            }

            this.testEntitys = testEntitys;
        }

        public void OnPost(int id)
        {
            OnGet();
            currentTest = testEntitys.Find(x => x.Id == id);
        }
    }
}
