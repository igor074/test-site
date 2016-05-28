using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using TestSite.Models.Configurations;

namespace TestSite.Models
{
    public class User : IdentityUser
    {
        public int GroupID { get; set; }
        public Group Group { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }

        public ICollection<Test> Tests { get; set; }

        public User()
        {
            Tests = new List<Test>();
        }
    }

    public class ApplicationDbContext : IdentityDbContext<User>
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
            modelBuilder.Entity<LearnerAnswer>().HasKey(l => new { l.AnswerID, l.UserID, l.QuestionID});
            modelBuilder.Entity<QuestionArea>().HasKey(o => o.QuestionAreaID);
            modelBuilder.Entity<Question>().HasKey(q => new { q.QuestionID });
            modelBuilder.Entity<QuestionType>().HasKey(q => q.QuestionTypeID);
            modelBuilder.Entity<Test>().HasKey(t => t.TestID);
            modelBuilder.Entity<Group>().HasKey(g => new { g.GroupID });

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