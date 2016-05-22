using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestSite.Models.Configurations;

namespace TestSite.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("name=DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>().HasKey(a => a.AnswerID);
            modelBuilder.Entity<AnswerQuestion>().HasKey(a => new { a.AnswerID, a.QuestionID });
            modelBuilder.Entity<Institution>().HasKey(i => i.InstitutionID);
            modelBuilder.Entity<Learner>().HasKey(l => l.LearnerID);
            modelBuilder.Entity<LearnerAnswer>().HasKey(l => new { l.AnswerID, l.LearnerID, l.OlympiadID, l.QuestionID});
            modelBuilder.Entity<QuestionArea>().HasKey(o => o.QuestionAreaID);
            modelBuilder.Entity<Olympiad>().HasKey(o => o.OlympiadID);
            modelBuilder.Entity<Question>().HasKey(q => q.QuestionID);
            modelBuilder.Entity<QuestionType>().HasKey(q => q.QuestionTypeID);
            modelBuilder.Entity<Test>().HasKey(t => t.TestID);

            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<Learner> Learners { get; set; }
        public virtual DbSet<LearnerAnswer> LearnerAnswers { get; set; }
        public virtual DbSet<QuestionArea> QuestionAreas { get; set; }
        public virtual DbSet<Olympiad> Olympiads { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
    }
}