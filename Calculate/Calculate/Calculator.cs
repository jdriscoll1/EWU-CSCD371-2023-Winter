using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Calculator<T> where T : INumber<T> 


    {
        public static readonly Func<T, T, T> Add = (T param1, T param2) => param1 + param2;
        public static readonly Func<T, T, T> Subtract = (T param1, T param2) => param1 - param2;
        public static readonly Func<T, T, T> Multiply = (T param1, T param2) => param1 * param2;
        public static readonly Func<T, T, T> Divide = (T param1, T param2) => param1 / param2;

        public static readonly IReadOnlyDictionary<char, Func<T, T, T>> mathematicalOperations = new Dictionary<char, Func<T, T, T>> 
        { 
            ['+'] = Add,
            ['-'] = Subtract,
            ['*'] = Multiply,
            ['/'] = Divide        
        };

        public static T? TryCalculate (string equation)
        {
            string[] equationArray = equation.Split(" ");
            if ((Convert.ChangeType(equationArray[0], typeof(T)), equationArray[1][0], Convert.ChangeType(equationArray[2], typeof(T))) is (T operand1, char operatorChar, T operand2)) {
                return mathematicalOperations[operatorChar](operand1, operand2); 
            
            }
            return default; 





        }
 
    }
}
