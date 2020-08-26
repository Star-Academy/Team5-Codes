using System;

namespace Phase8
{
    class Output
    {
        public static void Throw(string s)
        {
            throw new Exception(s);
        }

        public static void Write(string s)
        {
            Console.WriteLine(s);
        }
    }
}
