﻿namespace onlinesinavportali.Models
{
    public class Student
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        public string UserName { get; set; }
        public string Email { get; set; }

        public string Password { get; set; }
        public string PhotoUrl { get; set; }
        public List<ExamResult> ExamResults { get; set; }
    }
}
