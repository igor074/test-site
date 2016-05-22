namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AnswerQuestions",
                c => new
                    {
                        AnswerID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        IsRight = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.AnswerID, t.QuestionID })
                .ForeignKey("dbo.Answers", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.AnswerID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Answers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false, identity: true),
                        AnswerText = c.String(),
                    })
                .PrimaryKey(t => t.AnswerID);
            
            CreateTable(
                "dbo.Questions",
                c => new
                    {
                        QuestionID = c.Int(nullable: false, identity: true),
                        QuestionTypeID = c.Int(nullable: false),
                        QuestionAreaID = c.Int(nullable: false),
                        Complexity = c.Int(),
                        Text = c.String(),
                        Points = c.Int(),
                        ImagePath = c.String(),
                    })
                .PrimaryKey(t => t.QuestionID)
                .ForeignKey("dbo.QuestionAreas", t => t.QuestionAreaID, cascadeDelete: true)
                .ForeignKey("dbo.QuestionTypes", t => t.QuestionTypeID, cascadeDelete: true)
                .Index(t => t.QuestionAreaID)
                .Index(t => t.QuestionTypeID);
            
            CreateTable(
                "dbo.QuestionAreas",
                c => new
                    {
                        QuestionAreaID = c.Int(nullable: false, identity: true),
                        QuestionAreaName = c.String(),
                    })
                .PrimaryKey(t => t.QuestionAreaID);
            
            CreateTable(
                "dbo.QuestionTypes",
                c => new
                    {
                        QuestionTypeID = c.Int(nullable: false, identity: true),
                        QuestionTypeName = c.String(),
                    })
                .PrimaryKey(t => t.QuestionTypeID);
            
            CreateTable(
                "dbo.Tests",
                c => new
                    {
                        TestID = c.Int(nullable: false, identity: true),
                        TestName = c.String(),
                    })
                .PrimaryKey(t => t.TestID);
            
            CreateTable(
                "dbo.Institutions",
                c => new
                    {
                        InstitutionID = c.Int(nullable: false, identity: true),
                        InstitutionName = c.String(),
                        InstitutionPlace = c.String(),
                        InstitutionAddress = c.String(),
                    })
                .PrimaryKey(t => t.InstitutionID);
            
            CreateTable(
                "dbo.LearnerAnswers",
                c => new
                    {
                        AnswerID = c.Int(nullable: false),
                        LearnerID = c.Int(nullable: false),
                        OlympiadID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        LearnerAnswer1 = c.String(),
                    })
                .PrimaryKey(t => new { t.AnswerID, t.LearnerID, t.OlympiadID, t.QuestionID })
                .ForeignKey("dbo.Answers", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.Learners", t => t.LearnerID, cascadeDelete: true)
                .ForeignKey("dbo.Olympiads", t => t.OlympiadID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .Index(t => t.AnswerID)
                .Index(t => t.LearnerID)
                .Index(t => t.OlympiadID)
                .Index(t => t.QuestionID);
            
            CreateTable(
                "dbo.Learners",
                c => new
                    {
                        LearnerID = c.Int(nullable: false, identity: true),
                        InstitutionID = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                    })
                .PrimaryKey(t => t.LearnerID)
                .ForeignKey("dbo.Institutions", t => t.InstitutionID, cascadeDelete: true)
                .Index(t => t.InstitutionID);
            
            CreateTable(
                "dbo.Olympiads",
                c => new
                    {
                        OlympiadID = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Status = c.String(),
                        Condition = c.Boolean(),
                    })
                .PrimaryKey(t => t.OlympiadID);
            
            CreateTable(
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IdentityUserRoles",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(maxLength: 128),
                        Role_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.RoleId)
                .ForeignKey("dbo.IdentityRoles", t => t.Role_Id)
                .ForeignKey("dbo.IdentityUsers", t => t.UserId)
                .Index(t => t.Role_Id)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TestQuestions",
                c => new
                    {
                        Test_TestID = c.Int(nullable: false),
                        Question_QuestionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Test_TestID, t.Question_QuestionID })
                .ForeignKey("dbo.Tests", t => t.Test_TestID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.Question_QuestionID, cascadeDelete: true)
                .Index(t => t.Test_TestID)
                .Index(t => t.Question_QuestionID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "Role_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.LearnerAnswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.LearnerAnswers", "OlympiadID", "dbo.Olympiads");
            DropForeignKey("dbo.LearnerAnswers", "LearnerID", "dbo.Learners");
            DropForeignKey("dbo.Learners", "InstitutionID", "dbo.Institutions");
            DropForeignKey("dbo.LearnerAnswers", "AnswerID", "dbo.Answers");
            DropForeignKey("dbo.AnswerQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_TestID", "dbo.Tests");
            DropForeignKey("dbo.Questions", "QuestionTypeID", "dbo.QuestionTypes");
            DropForeignKey("dbo.Questions", "QuestionAreaID", "dbo.QuestionAreas");
            DropForeignKey("dbo.AnswerQuestions", "AnswerID", "dbo.Answers");
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Role_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_Id" });
            DropIndex("dbo.LearnerAnswers", new[] { "QuestionID" });
            DropIndex("dbo.LearnerAnswers", new[] { "OlympiadID" });
            DropIndex("dbo.LearnerAnswers", new[] { "LearnerID" });
            DropIndex("dbo.Learners", new[] { "InstitutionID" });
            DropIndex("dbo.LearnerAnswers", new[] { "AnswerID" });
            DropIndex("dbo.AnswerQuestions", new[] { "QuestionID" });
            DropIndex("dbo.TestQuestions", new[] { "Question_QuestionID" });
            DropIndex("dbo.TestQuestions", new[] { "Test_TestID" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeID" });
            DropIndex("dbo.Questions", new[] { "QuestionAreaID" });
            DropIndex("dbo.AnswerQuestions", new[] { "AnswerID" });
            DropTable("dbo.TestQuestions");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.Olympiads");
            DropTable("dbo.Learners");
            DropTable("dbo.LearnerAnswers");
            DropTable("dbo.Institutions");
            DropTable("dbo.Tests");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.QuestionAreas");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.AnswerQuestions");
        }
    }
}
