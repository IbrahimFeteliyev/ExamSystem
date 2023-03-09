namespace ExamSystem_MVC_.Models
{
    public class Question : Base
    {
        public int SubjectId { get; set; }
        public Subject Subject { get; set; }
        public string QuestionText { get; set; }
        public string? PhotoUrl { get; set; }
        public string VariantA { get; set; }
        public string VariantB { get; set; }
        public string VariantC { get; set; }
        public string VariantD { get; set; }
        public char CorrectAnswer { get; set; }
    }
}
