namespace Personnel_testing_HR_CR.Data.Entity
{
    public class TestEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Questions { get; set; }

    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string Comment { get; set; }
        public List<Answer> Answers { get; set; }
        public string AnswerQ { get; set; }
    }

    public class QuestionResult
    {
        public int QuestionResultID { get; set; }
        public string QuestionText { get; set; }
        public string? Comment { get; set; }
        public List<AnswerResult> Answers { get; set; }
        public string AnswerQ { get; set; }
        public string AnswerUser { get; set; }
    }


    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class AnswerResult
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }


    public class ResultTest
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int IdTest { get; set; }
        public string Title { get; set; }
        public string Date { get; set; }
        public List<QuestionResult> QuestionsResult { get; set; }
    }
}
