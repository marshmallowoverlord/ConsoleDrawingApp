using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DrawingApp;
using System.Text;

namespace Testing
{
    [TestClass]
    public class ProgramTest
    {
        [TestMethod]
        public void TestProgramMainBasic()
        {
            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                PrivateType privateTypeObject = new PrivateType(typeof(Program));
                privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|\0\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("|\0\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("|\0\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainLine()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "l 1 1 1 3");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|x\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("|x\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("|x\0\0\0\0|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainRectangle()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "r 2 1 5 3");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|\0xxxx|").Append(Environment.NewLine);
                sb.Append("|\0x\0\0x|").Append(Environment.NewLine);
                sb.Append("|\0xxxx|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainBucket()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "b 1 1 o");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|ooooo|").Append(Environment.NewLine);
                sb.Append("|ooooo|").Append(Environment.NewLine);
                sb.Append("|ooooo|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainRectangleBucket1()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");
            privateTypeObject.InvokeStatic("ProcessInput", "r 2 1 5 3");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "b 1 1 o");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|oxxxx|").Append(Environment.NewLine);
                sb.Append("|ox\0\0x|").Append(Environment.NewLine);
                sb.Append("|oxxxx|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainRectangleBucket2()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");
            privateTypeObject.InvokeStatic("ProcessInput", "r 2 1 5 3");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "b 2 2 o");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|\0oooo|").Append(Environment.NewLine);
                sb.Append("|\0o\0\0o|").Append(Environment.NewLine);
                sb.Append("|\0oooo|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }

        [TestMethod]
        public void TestProgramMainAll()
        {
            PrivateType privateTypeObject = new PrivateType(typeof(Program));
            privateTypeObject.InvokeStatic("ProcessInput", "c 5 3");
            privateTypeObject.InvokeStatic("ProcessInput", "r 2 1 5 3");
            privateTypeObject.InvokeStatic("ProcessInput", "b 2 2 o");

            using (ConsoleOutput consoleOutput = new ConsoleOutput())
            {
                privateTypeObject.InvokeStatic("ProcessInput", "l 3 1 3 3");

                StringBuilder sb = new StringBuilder();
                sb.Append("-------").Append(Environment.NewLine);
                sb.Append("|\0oxoo|").Append(Environment.NewLine);
                sb.Append("|\0ox\0o|").Append(Environment.NewLine);
                sb.Append("|\0oxoo|").Append(Environment.NewLine);
                sb.Append("-------");

                string expected = sb.ToString();

                Assert.AreEqual<string>(expected, consoleOutput.GetOutput().Trim());
            }
        }
    }
}
