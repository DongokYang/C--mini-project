using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            decimal[] gradeItems = { 92,82,77,72,67,62,55,10};

            foreach(int grade in gradeItems)
            {
                GradeItem test = new GradeItem(grade,100);
                Console.WriteLine(test.GetLetterGrade());
            }

        }
    }
}
