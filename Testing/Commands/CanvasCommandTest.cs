using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp.Exceptions;
using DrawingApp;
using DrawingApp.Commands;

namespace Testing.Commands
{
    [TestClass]
    public class CanvasCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandMissingExpetedParams()
        {
            string input = "c 6";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandNegativeWidth()
        {
            string input = "c -5 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandNegativeHeight()
        {
            string input = "c 5 -2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandZeroWidth()
        {
            string input = "c 0 -2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandZeroHeight()
        {
            string input = "c 6 0";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandUnexpectedParam()
        {
            string input = "c 6 10 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestCanvasCommandInvalidParamType()
        {
            string input = "c 10 h";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        public void TestCanvasCommandInstance()
        {
            string input = "c 10 12";
            CommandEntity command = CommandFactory.GetCommand(input);

            Assert.IsInstanceOfType(command, typeof(CanvasCommand));
        }
    }
}
