using System.ComponentModel.DataAnnotations;

namespace onlinesinavportali.Models
{
    public class QuestionAndOptions
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string CorrectAnswer { get; set; }
        public string? SelectedOption { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
    }
}
