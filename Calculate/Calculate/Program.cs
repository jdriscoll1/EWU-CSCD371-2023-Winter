using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculate
{
    public class Program
    {
        public readonly static Action<string> WriteLine = Console.WriteLine;

        public readonly static Func<string?> ReadLine = Console.ReadLine; 

        static public void Main() {
            Console.WriteLine("The Program");
        }
    }
}
