using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator
    {
        public static readonly Func<int, int, int> Add = (int param1, int param2) => param1 + param2;
        public static readonly Func<int, int, int> Subtract = (int param1, int param2) => param1 - param2;
        public static readonly Func<int, int, int> Multiply = (int param1, int param2) => param1 * param2;
        public static readonly Func<int, int, int> Divide = (int param1, int param2) => param1 / param2;

        public static readonly IReadOnlyDictionary<char, Func<int, int, int>> mathematicalOperations = new Dictionary<char, Func<int, int, int>> 
        { 
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide        
        };

        public static int? TryCalculate (string equation)
        {
            string[] equationArray = equation.Split(" ");
            if ((int.Parse(equationArray[0]), equationArray[1][0], int.Parse(equationArray[2])) is (int operand1, char operatorChar, int operand2)) {
                return mathematicalOperations[operatorChar](operand1, operand2); 
            
            }
            return null; 





        }
    }
}
