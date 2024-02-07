using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class GradeItem
    {
        private decimal score;
        private decimal maxScore;

        public GradeItem(decimal specifiedScore, decimal maxScore)
        {
            setSpecifiedScore(specifiedScore);
            setmaxScore(maxScore);

        }

        public void setSpecifiedScore(decimal specifiedScore) {
            this.score = specifiedScore;
        }
        public void setmaxScore(decimal maxScore)
        {
            this.maxScore = maxScore;
        }
        public LetterGrade GetLetterGrade() {
            if (score >= 90)
            { 
                return LetterGrade.APlus;
            }
            else if (score >= 80)
            {
                return LetterGrade.A;
            }
            else if (score >= 75)
            {
                return LetterGrade.BPlus;
            }
            else if (score >= 70)
            {
                return LetterGrade.B;
            }
            else if (score >= 65)
            {
                return LetterGrade.CPlus;
            }
            else if (score >= 60)
            {
                return LetterGrade.C;

            }
            else if (score >= 50)
            {
                return LetterGrade.D;
            }
            else
            {
                return LetterGrade.F;
            }
        }

    }
}
