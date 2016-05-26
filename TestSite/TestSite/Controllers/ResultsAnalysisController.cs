using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestSite.Models;

namespace TestSite.Controllers
{
    public class ResultsAnalysisController : Controller
    {
        //
        // GET: /ResultsAnalysis/
        public ActionResult Index()
        {
            ResultsAnalysisModelView mv = new ResultsAnalysisModelView()
            {
                LearnerName = "Смирнов Иван",
                GroupName = "КТ-150",
                InstitutionName = "ОмГТУ",

                SimpleFinalMark = 4,
                SimpleCountRightAnswers = 35,
                SimpleTotalQuestionsCount = 40,

                SimpleTimeFinalMark = 3,
                SimpleTimeCountRightAnswers = 35,
                SimpleTimeTotalQuestionsCount = 40,
                SimpleTimeTotalAnswersOvertimeCount = 10,

                LevelCountRightAnswers = 35,
                LevelTotalQuestionsCount = 40,
                LevelUnderstanding1 = "4",
                LevelUnderstanding2 = "-",
                LevelUnderstanding3 = "-",
                LevelUnderstanding4 = "-",
                LevelUnderstanding5 = "-",

                LineApproximationFinalMark = 4,
                LineApproximationCountRightAnswers = 35,
                LineApproximationTotalQuestionsCount = 40,
                LineApproximationTotalAnswersOvertimeCount = 10,
                LineApproximationAttemptCount = 1,

                StatisticFinalMark = 4,
                StatisticCountRightAnswers = 35,
                StatisticTotalQuestionsCount = 40,
                StatisticDispersion = 271,
                StatisticResult = "Экспоненциальный"
            };
            return View(mv);
        }
	}
}