namespace Personnel_testing_HR_CR.Data.DTO
{

    public class QuestionDTO
    {
        public int QuestionID { get; set; }
        public string QuestionText { get; set; }
        public string AnswerQ { get; set; }
    }

    public class ResultUserDTO
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public int IdTest { get; set; }
        public List<QuestionDTO> QuestionsResult { get; set; }
    }
}
