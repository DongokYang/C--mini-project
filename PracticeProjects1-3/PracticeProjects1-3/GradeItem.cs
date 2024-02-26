using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PracticeProjects1_3.Program;

namespace PracticeProjects1_3
{
    internal class GradeItem
    {
        decimal score;
        decimal maxScore;

        public GradeItem(decimal score, decimal maxScore)
        {
            this.score = score;
            this.maxScore = maxScore;
        }

        public LetterGrade GetLetterGrade(decimal score)
        {
            if (score >= 90)
                return LetterGrade.APlus;
            else if (score >= 80)
                return LetterGrade.A;
            else if (score >= 75)
                return LetterGrade.BPlus;
            else if (score >= 70)
                return LetterGrade.B;
            else if (score >= 65)
                return LetterGrade.CPlus;
            else if (score >= 60)
                return LetterGrade.C;
            else if (score >= 50)
                return LetterGrade.D;
            else
                return LetterGrade.F;
        }
    }
}
