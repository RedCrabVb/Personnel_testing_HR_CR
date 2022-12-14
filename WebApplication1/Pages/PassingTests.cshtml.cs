using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Personnel_testing_HR_CR.Data;
using Personnel_testing_HR_CR.Data.Entity;

namespace Personnel_testing_HR_CR.Pages
{
    public class PassingTestsModel : PageModel
    {
        private readonly ILogger<PassingTestsModel> _logger;
        public string Name { get; set; }
        public TestEntity testEntity { get; set; }
        public ApplicationDbContext _ctx;
        public bool isEnd = false;
        public PassingTestsModel(ILogger<PassingTestsModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _ctx = context;
        }

        public void OnGet(int id)
        {
            if (id == -1)
            {
                this.isEnd = true;
            }
            else {
                var test = _ctx.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

                var questionsId = _ctx.Tests.Where(x => x.Id == id).Include(x => x.Questions).First();

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

                this.testEntity = test;
                test.Questions = questions;
            }
        }


    }
}