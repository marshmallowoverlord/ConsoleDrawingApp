using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp.Exceptions;
using DrawingApp;
using DrawingApp.Commands;

namespace Testing.Commands
{
    [TestClass]
    public class LineCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandMissingExpetedParams()
        {
            string input = "l 1";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandInvalidDirection()
        {
            string input = "l 1 5 2 3";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandNegativeX1()
        {
            string input = "l -2 2 1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandNegativeY1()
        {
            string input = "l 2 -1 2 4";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandNegativeX2()
        {
            string input = "l 2 2 -1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandNegativeY2()
        {
            string input = "l 1 3 1 -1";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandZeroX1()
        {
            string input = "l 0 2 1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandZeroY1()
        {
            string input = "l 2 0 2 4";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandZeroX2()
        {
            string input = "l 2 2 0 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandZeroY2()
        {
            string input = "l 1 3 1 0";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandUnexpectedParam()
        {
            string input = "l 6 10 6 5 3";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestLineCommandInvalidParamType()
        {
            string input = "l 2 y 2 8";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        public void TestLineCommandInstance()
        {
            string input = "l 2 4 2 8";
            CommandEntity command = CommandFactory.GetCommand(input);

            Assert.IsInstanceOfType(command, typeof(LineCommand));
        }
    }
}
