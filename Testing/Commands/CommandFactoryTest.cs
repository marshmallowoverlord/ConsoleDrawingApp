using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp;
using DrawingApp.Commands;
using DrawingApp.Exceptions;

namespace Testing
{
    [TestClass]
    public class CommandFactoryTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandException))]
        public void TestUnknownCommand()
        {
            string input = "z";
            CommandEntity command = CommandFactory.GetCommand(input);
        }
    }
}
