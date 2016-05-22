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
              new QuestionType { QuestionTypeName = "Один правильный ответ" },
              new QuestionType { QuestionTypeName = "Несколько правильных ответов" },
              new QuestionType { QuestionTypeName = "Вставка значений" },
              new QuestionType { QuestionTypeName = "Развернутый ответ" },
              new QuestionType { QuestionTypeName = "Установление соответствий" },
              new QuestionType { QuestionTypeName = "Расположение в хронологическом порядке" },
              new QuestionType { QuestionTypeName = "Выделение в тексте" },
              new QuestionType { QuestionTypeName = "Количественное сравнение" },
              new QuestionType { QuestionTypeName = "Выбор графика" }
            );

            context.QuestionAreas.AddOrUpdate(
              new QuestionArea { QuestionAreaName = "Русский язык"},
              new QuestionArea { QuestionAreaName = "Математика"},
              new QuestionArea { QuestionAreaName = "География"}
            );
            
        }
    }
}
