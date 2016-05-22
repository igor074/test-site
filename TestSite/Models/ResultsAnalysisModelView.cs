using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class ResultsAnalysisModelView
    {
        public string LearnerName { get; set; }
        public string GroupName { get; set; }
        public string InstitutionName { get; set; }

        // Простая модель
        public int SimpleFinalMark { get; set; }
        public int SimpleCountRightAnswers { get; set; }
        public int SimpleTotalQuestionsCount { get; set; }

        // С учетом времени
        public int SimpleTimeFinalMark { get; set; }
        public int SimpleTimeCountRightAnswers { get; set; }
        public int SimpleTimeTotalQuestionsCount { get; set; }
        public int SimpleTimeTotalAnswersOvertimeCount { get; set; }

        // Уровень усвоения
        public int LevelCountRightAnswers { get; set; }
        public int LevelTotalQuestionsCount { get; set; }
        public string LevelUnderstanding1 { get; set; }
        public string LevelUnderstanding2 { get; set; }
        public string LevelUnderstanding3 { get; set; }
        public string LevelUnderstanding4 { get; set; }
        public string LevelUnderstanding5 { get; set; }

        // Линейно-кусочная аппроксимация
        public int LineApproximationFinalMark { get; set; }
        public int LineApproximationCountRightAnswers { get; set; }
        public int LineApproximationTotalQuestionsCount { get; set; }
        public int LineApproximationTotalAnswersOvertimeCount { get; set; }
        public int LineApproximationAttemptCount { get; set; }

        // Статистическая модель
        public int StatisticFinalMark { get; set; }
        public int StatisticCountRightAnswers { get; set; }
        public int StatisticTotalQuestionsCount { get; set; }
        public double StatisticDispersion { get; set; }
        public double[,] GraphicData { get; set; }

        public ResultsAnalysisModelView() { }

    }
}