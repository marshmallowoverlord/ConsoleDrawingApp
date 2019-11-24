using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp;
using DrawingApp.Commands;
using DrawingApp.Exceptions;

namespace Testing
{
    [TestClass]
    public class QuitCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestQuitCommandUnexpectedParam()
        {
            string input = "q 1";
            CommandEntity command = CommandFactory.GetCommand(input);
        }
    }
}
