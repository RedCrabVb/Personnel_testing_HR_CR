namespace Personnel_testing_HR_CR.Data.Entity
{
    public class TestEntity
    {
        public Question[] questions { get; set; }

    }

    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public Answer[] Answers { get; set; }
        public string AnswerQ { get; set; }
    }

    public class Answer
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
