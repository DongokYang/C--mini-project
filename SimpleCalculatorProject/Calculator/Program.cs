using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calculator
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Input inputHandler = new Input();
            inputHandler.gettingInput();
            Console.WriteLine();

        }
    }
}

/*
Goals
 make a calculator ( not caring calcualting order)

(currently working on this) Make a exception handling
    1. number + number >> error
    2. operator + operatro >> error
    3. number + operator in the same line >> error
    4. non numeric input 

    
Make a unit test part 
Make a calcualotr ( caring order)
updates exception handling & unit test

make it GUI 
 */