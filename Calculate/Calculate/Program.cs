using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Program
    {
        public Action<string> WriteLine { get; init; } = Console.WriteLine;

        public Func<string?> ReadLine { get; init; } = Console.ReadLine;


        static public void Main() {
            Program program = new Program();
            bool userInputIncorrect = false;
            int? result = null;
            string? userInput = null; 
            do
            {
                program.WriteLine("Please input an equation of form <operator> <operand> <operator>");
                userInputIncorrect = false;
                userInput = program.ReadLine();
                try
                {
                    result = Calculator.TryCalculate(userInput!);
                }
                catch (ArgumentNullException)
                {
                    program.WriteLine("Please Enter a Non-Null Input");
                    userInputIncorrect = true;

                }
                catch (FormatException)
                {
                    program.WriteLine("Please Enter a Valid Input");
                    userInputIncorrect = true;

                }
            } while (userInputIncorrect);
            program.WriteLine($"The Result of the following equation: {userInput} is {result}");

        }
    }
}
