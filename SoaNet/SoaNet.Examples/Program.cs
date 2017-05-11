using System;
using System.Collections.Generic;
using System.Text;

namespace SoaNet.Examples
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var example = new LazyParameterExample();
            var builtExample = example.BuildExample();

            builtExample.Run();
        }
    }
}
