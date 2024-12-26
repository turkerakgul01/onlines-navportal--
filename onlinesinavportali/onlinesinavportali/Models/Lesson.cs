namespace onlinesinavportali.Models
{
    public class Lesson
    {
        public int LessonId { get; set; }
        public string LessonName { get; set; }
        
        public List<Exam> Exams { get;}
    }
}
