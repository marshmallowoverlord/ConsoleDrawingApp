using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace Testing
{
    public class ConsoleOutput : IDisposable
    {
        private StringWriter stringWriter;
        private TextWriter standardOut;

        public ConsoleOutput()
        {
            stringWriter = new StringWriter();
            standardOut = Console.Out;
            Console.SetOut(stringWriter);
        }

        public string GetOutput()
        {
            return stringWriter.ToString();
        }

        public void Dispose()
        {
            Console.SetOut(standardOut);
            stringWriter.Dispose();
        }
    }
}
