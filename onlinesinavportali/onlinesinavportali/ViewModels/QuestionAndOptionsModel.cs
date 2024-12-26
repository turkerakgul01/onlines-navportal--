using System.ComponentModel.DataAnnotations;

namespace onlinesinavportali.ViewModels
{
    public class QuestionAndOptionsModel
    {
        [Key]
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public string A { get; set; }
        public string B { get; set; }
        public string C { get; set; }
        public string D { get; set; }
        public string CorrectAnswer { get; set; }
        public int ExamId { get; set; }
    }
}
