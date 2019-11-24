using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Testing
{
    public class ConsoleInput : IDisposable
    {
        private StringReader StringReader;
        private TextReader StandardIn;

        public ConsoleInput(string input)
        {
            StringReader = new StringReader(input);
            StandardIn = Console.In;
            Console.SetIn(StringReader);
        }

        public string GetInput()
        {
            return StandardIn.ToString();
        }

        public void Dispose()
        {
            Console.SetIn(StandardIn);
            StringReader.Dispose();
        }
    }
}
