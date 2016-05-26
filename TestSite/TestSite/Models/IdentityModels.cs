using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestSite.Models.Configurations;

namespace TestSite.Models
{
    public class ApplicationUser : IdentityUser
    {
        public int GroupID { get; set; }
        public Group Group { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
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
            modelBuilder.Entity<LearnerAnswer>().HasKey(l => new { l.AnswerID, l.Id, l.QuestionID});
            modelBuilder.Entity<QuestionArea>().HasKey(o => o.QuestionAreaID);
            modelBuilder.Entity<Question>().HasKey(q => new { q.QuestionID, q.QuestionAreaID, q.QuestionTypeID });
            modelBuilder.Entity<QuestionType>().HasKey(q => q.QuestionTypeID);
            modelBuilder.Entity<Test>().HasKey(t => t.TestID);
            modelBuilder.Entity<Group>().HasKey(g => new { g.GroupID, g.InstitutionID});

            modelBuilder.Configurations.Add(new IdentityUserLoginConfiguration());
            modelBuilder.Configurations.Add(new IdentityUserRoleConfiguration());
        }

        public virtual DbSet<Answer> Answers { get; set; }
        public virtual DbSet<AnswerQuestion> AnswerQuestions { get; set; }
        public virtual DbSet<Institution> Institutions { get; set; }
        public virtual DbSet<LearnerAnswer> LearnerAnswers { get; set; }
        public virtual DbSet<QuestionArea> QuestionAreas { get; set; }
        public virtual DbSet<Question> Questions { get; set; }
        public virtual DbSet<QuestionType> QuestionTypes { get; set; }
        public virtual DbSet<Test> Tests { get; set; }
        public virtual DbSet<Group> Groups { get; set; }
    }
}