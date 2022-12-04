using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Personnel_testing_HR_CR.Data;
using Personnel_testing_HR_CR.Data.Entity;

namespace Personnel_testing_HR_CR.Pages
{
    public class OverviewResultsModel : PageModel
    {
        public List<ResultTest> resultTests { get; set; }
        public ResultTest currentTest { get; set; }
        private readonly ILogger<PassingTestsModel> _logger;
        public ApplicationDbContext _ctx;

        public OverviewResultsModel(ILogger<PassingTestsModel> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _ctx = context;
        }

        public void OnGet(string fullname)
        {
            resultTests = new List<ResultTest>();
            var tests = _ctx.ResultTests.Where(x => fullname == null ? true : x.Fullname == fullname).Include(x => x.QuestionsResult).ToList();

            foreach (var test in tests)
            {
                var questionsId = _ctx.ResultTests.Where(x => x.Id == test.Id).Include(x => x.QuestionsResult).ToList().First();

                var questions = _ctx.QuestionResults.Where(q => questionsId.QuestionsResult.Contains(q)).Select(q => new QuestionResult
                {
                    QuestionResultID = q.QuestionResultID,
                    QuestionText = q.QuestionText,
                    AnswerQ = q.AnswerQ,
                    Answers = q.Answers.Select(c => new AnswerResult
                    {
                        Id = c.Id,
                        Title = c.Title
                    }).ToList()

                }).ToList();

                test.QuestionsResult = questions;

                resultTests.Add(test);

                

            }

        }

        public void OnPost(int id)
        {
            OnGet(null);
            currentTest = resultTests.Find(x => x.Id == id);
        }

    }
}
