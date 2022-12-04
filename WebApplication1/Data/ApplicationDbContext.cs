using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Personnel_testing_HR_CR.Data.Entity;

namespace Personnel_testing_HR_CR.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TestEntity> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<ResultTest> ResultTests { get; set; }
        public DbSet<QuestionResult> QuestionResults { get; set; }
    }
}