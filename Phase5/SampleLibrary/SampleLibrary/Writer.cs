using Castle.Core.Internal;
using System;
using System.Collections.Generic;

namespace SampleLibrary
{
    public class Writer
    {
        public void Write(HashSet<string> result)
        {
            foreach (string str in result)
            {
                Console.WriteLine(str);
            }

            if (result.IsNullOrEmpty())
                Console.WriteLine("No result found.");
        }


    }
}
