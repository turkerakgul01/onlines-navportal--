using Microsoft.AspNetCore.Identity;

namespace onlinesinavportali.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }

        public List<ExamResult> ExamResults { get; set; }
    }
}
