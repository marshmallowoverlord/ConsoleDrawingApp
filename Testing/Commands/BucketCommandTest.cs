using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp.Exceptions;
using DrawingApp;
using DrawingApp.Commands;

namespace Testing.Commands
{
    [TestClass]
    public class BucketCommandTest
    {
        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandMissingExpetedParams()
        {
            string input = "b 6 4";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandNegativeX()
        {
            string input = "b -5 2 o";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandNegativeY()
        {
            string input = "b 5 -2 o";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandZeroWidth()
        {
            string input = "b 0 -2 o";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandZeroHeight()
        {
            string input = "b 6 0 o";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandUnexpectedParam()
        {
            string input = "b 6 10 o z";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandInvalidXYParamType()
        {
            string input = "b 10 y o";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidCommandParamsException))]
        public void TestBucketCommandInvalidColourChar()
        {
            string input = "b 10 2 oo";
            CommandEntity command = CommandFactory.GetCommand(input);
        }

        [TestMethod]
        public void TestBucketCommandInstance()
        {
            string input = "b 10 12 o";
            CommandEntity command = CommandFactory.GetCommand(input);

            Assert.IsInstanceOfType(command, typeof(BucketCommand));
        }
    }
}
