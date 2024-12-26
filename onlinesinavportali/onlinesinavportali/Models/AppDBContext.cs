using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using onlinesinavportali.ViewModels;

namespace onlinesinavportali.Models
{
    public class AppDBContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Kullanıcı adı ve şifre ile SQL Server bağlantısı için:
                optionsBuilder.UseSqlServer("server=LAPTOP-72HGJV78\\SQLEXPRESS;database=OnlineExam;User Id=sa;Password=1907Turker;TrustServerCertificate=True;");

                // Eğer kullanıcı adı ve şifre kullanmıyorsanız:
                // optionsBuilder.UseSqlServer("server=LAPTOP-72HGJV78\\SQLEXPRESS;database=OnlineExam;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        public DbSet<Admin> Admins { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public DbSet<ExamResult> ExamResults { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<QuestionAndOptions> QuestionsAndOptions { get; set; }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<QuestionAndOptionsModel> QuestionAndOptionsModel { get; set; } = default!;
    }
}
