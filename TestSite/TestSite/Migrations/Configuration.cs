namespace TestSite.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using TestSite.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<TestSite.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TestSite.Models.ApplicationDbContext context)
        {
            context.QuestionTypes.AddOrUpdate(
              new QuestionType { QuestionTypeName = "���� ���������� �����" },
              new QuestionType { QuestionTypeName = "��������� ���������� �������" },
              new QuestionType { QuestionTypeName = "������� ��������" },
              new QuestionType { QuestionTypeName = "����������� �����" },
              new QuestionType { QuestionTypeName = "������������ ������������" },
              new QuestionType { QuestionTypeName = "������������ � ��������������� �������" },
              new QuestionType { QuestionTypeName = "��������� � ������" },
              new QuestionType { QuestionTypeName = "�������������� ���������" },
              new QuestionType { QuestionTypeName = "����� �������" }
            );

            context.QuestionAreas.AddOrUpdate(
              new QuestionArea { QuestionAreaName = "������� ����"},
              new QuestionArea { QuestionAreaName = "����������"},
              new QuestionArea { QuestionAreaName = "���������"}
            );

            context.Institutions.AddOrUpdate(
              new Institution { InstitutionID = 1, InstitutionName = "�����" },
              new Institution { InstitutionID = 2, InstitutionName = "������" },
              new Institution { InstitutionID = 3, InstitutionName = "����" }
            );

            context.Groups.AddOrUpdate(
              new Group { InstitutionID = 1, GroupName = "A-510" },
              new Group { InstitutionID = 1, GroupName = "��-410" },
              new Group { InstitutionID = 1, GroupName = "���-320" }
            );
        }
    }
}
