using System;
using System.Collections.Generic;
using System.Linq;

namespace Team5_Codes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>(){1, 2, 3, 4, 5,};
            var a  = numbers.Select(x => x + 1000);
            foreach (var num in a) {
                Console.Write("{0}\n", a);
            }
        }
    }
}
