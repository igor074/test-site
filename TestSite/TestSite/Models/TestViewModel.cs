using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestSite.Models
{
    public class TestViewModel
    {
        public string TestName { get; set; }
        public int TestTime { get; set; }

        public List<SelectListItem> PathsTest = new List<SelectListItem>()
        {
            new SelectListItem() {Text = "Порядок хранения в БД"},
            new SelectListItem() {Text = "Блочная подача вопросов"},
            new SelectListItem() {Text = "Случайным образом"},
            new SelectListItem() {Text = "Блочная подача со временем"},
            new SelectListItem() {Text = "Модель нечеткой логики"},
            new SelectListItem() {Text = "Модель байесовской сети доверия"},
            new SelectListItem() {Text = "Модель на основе анализа ответов"}
        };

        public List<SelectListItem> Areas;

        public List<string> Questions;

        public TestViewModel()
        {
            Areas = new List<SelectListItem>();
            Questions = new List<string>();

            for (int i = 0; i < 50; i++)
            {
                Questions.Add("Вопрос " + (i + 1));
            }
        }
    }
}