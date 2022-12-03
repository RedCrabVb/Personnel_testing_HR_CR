using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebApplication1.Data.Entity;

namespace WebApplication1.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        public string Name { get; set; }
        public TestEntity testEntity { get; set; }

        public PrivacyModel(ILogger<PrivacyModel> logger)
        {
            _logger = logger;
            testEntity = new TestEntity();
            var answer = new Answer();
            answer.Title = "Answer1";
            answer.Id = 1;
            var answer2 = new Answer();
            answer2.Title = "Answer2";
            answer2.Id = 2;

            var answer3 = new Answer();
            answer3.Title = "Answer3";
            answer3.Id = 1;
            var answer4 = new Answer();
            answer4.Title = "Answer4";
            answer4.Id = 2;

            var question = new Question();
            var answers = new List<Answer>();
            answers.Add(answer);
            answers.Add(answer2);

            var question2 = new Question();
            var answers2 = new List<Answer>();
            answers2.Add(answer3);
            answers2.Add(answer4);

            question.Answers = answers.ToArray();
            question2.Answers = answers2.ToArray();

            var questions = new List<Question>();
            questions.Add(question);
            questions.Add(question2);
            testEntity.questions = questions.ToArray();
        }

        public void OnGet()
        {
        }

        //[HttpPost]
        //[Route("Privacy/submit")]
        //public string OnPostSubmit(TestEntity testEntityAnswer)
        //{
        //    this.Name = testEntityAnswer.ToString();
        //    return this.Name;
        //}


    }
}