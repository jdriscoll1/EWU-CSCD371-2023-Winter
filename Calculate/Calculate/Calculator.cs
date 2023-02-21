using System.ComponentModel;
using System.Globalization;
using System.Numerics;

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

        private static bool TryParse(string text, out T value)

        {
            value = default(T)!;
            try
            { 
                value = (T)Convert.ChangeType(text, typeof(T));
                return true;
            }
            catch
            { 
                return false;

            }
        }

        public static bool TryCalculate (string equation, out T result)
        {
            result = default!; 
            if (equation is null) {
                return false; 
            }
            string[] equationArray = equation.Split(" ");

            if (TryParse(equationArray[0], out T? operand1) && char.TryParse(equationArray[1], out char operatorChar) && TryParse(equationArray[2], out T? operand2))
            {
              
                result = mathematicalOperations[operatorChar](operand1, operand2);
                return true; 
            } 
            return false; 
        }
 
    }
}
