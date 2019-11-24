using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp.Exceptions;
using DrawingApp;
using DrawingApp.Commands;

namespace Testing.Commands
{
    [TestClass]
    public class RectangleCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandMissingExpetedParams()
        {
            string input = "r 1";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandNegativeX1()
        {
            string input = "r -2 2 1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandNegativeY1()
        {
            string input = "r 2 -1 2 4";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandNegativeX2()
        {
            string input = "r 2 2 -1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandNegativeY2()
        {
            string input = "r 1 3 1 -1";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandZeroX1()
        {
            string input = "r 0 2 1 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandZeroY1()
        {
            string input = "r 2 0 2 4";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandZeroX2()
        {
            string input = "r 2 2 0 2";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandZeroY2()
        {
            string input = "r 1 3 1 0";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandUnexpectedParam()
        {
            string input = "r 6 10 6 5 3";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestRectangleCommandInvalidParamType()
        {
            string input = "r 2 y 2 8";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        public void TestRectangleCommandInstance()
        {
            string input = "r 2 4 2 8";
            CommandEntity command = CommandFactory.GetCommand(input);

            Assert.IsInstanceOfType(command, typeof(RectangleCommand));
        }
    }
}
