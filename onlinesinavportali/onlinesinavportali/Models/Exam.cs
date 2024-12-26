namespace onlinesinavportali.Models
{
    public class Exam
    {
        public int ExamId { get; set; }
        public string ExamName { get; set; }
        public DateTime ExamDate { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<QuestionAndOptions> Questions { get;}
        public List<ExamResult> ExamResults { get; set; }


    }
}
