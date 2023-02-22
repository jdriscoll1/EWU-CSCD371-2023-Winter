using ConsoleUtilities;

namespace Calculate
{
    public class Program : ProgramBase
    {

         static public void Main() {
            Program program = new();
            bool userInputIncorrect = false;
            string? userInput = null;
            int result; 

            do
            {
                program.WriteLine("Please input an equation of form <operator> <operand> <operator>");
                userInputIncorrect = false;
                userInput = program.ReadLine();
                if (!Calculator<int>.TryCalculate(userInput!, out result)) {
                    program.WriteLine("Please Enter a Valid Input");
                    userInputIncorrect = true;
                }
                   

                
            } while (userInputIncorrect);
            program.WriteLine($"The Result of the following equation: {userInput} is {result}");

        }
    }
}
