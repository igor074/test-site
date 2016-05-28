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
                        SolvingTime = c.Int(),
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
                        Possibility = c.Double(nullable: false),
                        ParentQuestionAreaID = c.Int(nullable: false),
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
                        SolvingTime = c.Int(),
                    })
                .PrimaryKey(t => t.TestID);
            
            CreateTable(
                "dbo.IdentityUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        GroupID = c.Int(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        MiddleName = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Groups", t => t.GroupID, cascadeDelete: true)
                .Index(t => t.GroupID);
            
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
                "dbo.IdentityRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        InstitutionID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.GroupID)
                .ForeignKey("dbo.Institutions", t => t.InstitutionID, cascadeDelete: true)
                .Index(t => t.InstitutionID);
            
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
                        UserID = c.Int(nullable: false),
                        QuestionID = c.Int(nullable: false),
                        LearnerAnswer1 = c.String(),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.AnswerID, t.UserID, t.QuestionID })
                .ForeignKey("dbo.Answers", t => t.AnswerID, cascadeDelete: true)
                .ForeignKey("dbo.Questions", t => t.QuestionID, cascadeDelete: true)
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id)
                .Index(t => t.AnswerID)
                .Index(t => t.QuestionID)
                .Index(t => t.User_Id);
            
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
            
            CreateTable(
                "dbo.UserTests",
                c => new
                    {
                        User_Id = c.String(nullable: false, maxLength: 128),
                        Test_TestID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Test_TestID })
                .ForeignKey("dbo.IdentityUsers", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tests", t => t.Test_TestID, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Test_TestID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.LearnerAnswers", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.LearnerAnswers", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.LearnerAnswers", "AnswerID", "dbo.Answers");
            DropForeignKey("dbo.AnswerQuestions", "QuestionID", "dbo.Questions");
            DropForeignKey("dbo.UserTests", "Test_TestID", "dbo.Tests");
            DropForeignKey("dbo.UserTests", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUsers", "GroupID", "dbo.Groups");
            DropForeignKey("dbo.Groups", "InstitutionID", "dbo.Institutions");
            DropForeignKey("dbo.IdentityUserRoles", "UserId", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserRoles", "Role_Id", "dbo.IdentityRoles");
            DropForeignKey("dbo.IdentityUserLogins", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.IdentityUserClaims", "User_Id", "dbo.IdentityUsers");
            DropForeignKey("dbo.TestQuestions", "Question_QuestionID", "dbo.Questions");
            DropForeignKey("dbo.TestQuestions", "Test_TestID", "dbo.Tests");
            DropForeignKey("dbo.Questions", "QuestionTypeID", "dbo.QuestionTypes");
            DropForeignKey("dbo.Questions", "QuestionAreaID", "dbo.QuestionAreas");
            DropForeignKey("dbo.AnswerQuestions", "AnswerID", "dbo.Answers");
            DropIndex("dbo.LearnerAnswers", new[] { "User_Id" });
            DropIndex("dbo.LearnerAnswers", new[] { "QuestionID" });
            DropIndex("dbo.LearnerAnswers", new[] { "AnswerID" });
            DropIndex("dbo.AnswerQuestions", new[] { "QuestionID" });
            DropIndex("dbo.UserTests", new[] { "Test_TestID" });
            DropIndex("dbo.UserTests", new[] { "User_Id" });
            DropIndex("dbo.IdentityUsers", new[] { "GroupID" });
            DropIndex("dbo.Groups", new[] { "InstitutionID" });
            DropIndex("dbo.IdentityUserRoles", new[] { "UserId" });
            DropIndex("dbo.IdentityUserRoles", new[] { "Role_Id" });
            DropIndex("dbo.IdentityUserLogins", new[] { "User_Id" });
            DropIndex("dbo.IdentityUserClaims", new[] { "User_Id" });
            DropIndex("dbo.TestQuestions", new[] { "Question_QuestionID" });
            DropIndex("dbo.TestQuestions", new[] { "Test_TestID" });
            DropIndex("dbo.Questions", new[] { "QuestionTypeID" });
            DropIndex("dbo.Questions", new[] { "QuestionAreaID" });
            DropIndex("dbo.AnswerQuestions", new[] { "AnswerID" });
            DropTable("dbo.UserTests");
            DropTable("dbo.TestQuestions");
            DropTable("dbo.LearnerAnswers");
            DropTable("dbo.Institutions");
            DropTable("dbo.Groups");
            DropTable("dbo.IdentityRoles");
            DropTable("dbo.IdentityUserRoles");
            DropTable("dbo.IdentityUserLogins");
            DropTable("dbo.IdentityUserClaims");
            DropTable("dbo.IdentityUsers");
            DropTable("dbo.Tests");
            DropTable("dbo.QuestionTypes");
            DropTable("dbo.QuestionAreas");
            DropTable("dbo.Questions");
            DropTable("dbo.Answers");
            DropTable("dbo.AnswerQuestions");
        }
    }
}
