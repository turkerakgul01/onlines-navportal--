using System.ComponentModel.DataAnnotations;

namespace onlinesinavportali.Models
{
    public class ExamResult
    {
        [Key]
        public int ExamResultId { get; set; }
        public int CorrectCount { get; set; }
        public int WrongCount { get; set; }
        public double Result { get; set; }
        public int ExamId { get; set; }
        public Exam Exam { get; set; }
        public string AppUserID { get; set; }
        public AppUser AppUser { get; set; }
    }
}
