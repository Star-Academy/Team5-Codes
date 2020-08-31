using System;

namespace Phase8
{
    public class InputReader
    {
        private readonly string[] args;
        public InputReader(string[] args)
        {
            this.args = args;
        }
        public string ReadInput()
        {
            if (args.Length == 0)
                return Console.ReadLine();
            return args[0];
        }
        
    }
}