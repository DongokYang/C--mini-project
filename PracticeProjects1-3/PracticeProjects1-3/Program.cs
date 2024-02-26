using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProjects1_3
{
    internal class Program
    {
        public enum LetterGrade
        {
            F,
            D,
            C,
            CPlus,
            B,
            BPlus,
            A,
            APlus
        }
        static void Main(string[] args)
        {
            decimal[] myArray = { 92, 82, 77, 71, 66, 64, 51, 22 };

            foreach (decimal value in myArray)
            {
                GradeItem one = new GradeItem(value, 100);
                Console.WriteLine(one.GetLetterGrade(value));
            }

        }
    }
}
