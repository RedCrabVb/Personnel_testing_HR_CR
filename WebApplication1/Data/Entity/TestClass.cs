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

    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
