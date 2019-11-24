using DrawingApp;
using System;
using DrawingApp.Commands;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using DrawingApp.Sprites;
using System.IO;
using System.Text;

namespace Testing
{
    [TestClass]
    public class CanvasTest
    {
        [TestMethod]
        public void TestCanvasCreateCanvas()
        {
            int width = 10;
            int height = 10;

            CommandEntity command = new CanvasCommand(width, height);

            Canvas canvas = Canvas.CreateCanvas(command);

            Assert.AreEqual(width, canvas.Width);
            Assert.AreEqual(height, canvas.Height);
        }

        [TestMethod]
        public void TestCanvasUpdateCanvasArray()
        {
            int width = 3;
            int height = 3;
            char c = 'w';

            List<Point> points = new List<Point>
            {
                new Point(1,1), new Point (1,2), new Point(2,2)
            };

            Canvas canvas = new Canvas(width, height);

            PrivateObject privateObject = new PrivateObject(canvas);
            object[] args = new object[2] { points, c };
            privateObject.Invoke("UpdateCanvasArray", args);

            Char[,] canvasArray = canvas.GetCanvasArray();

            Assert.AreEqual(c, canvasArray[1, 1]);
            Assert.AreEqual(c, canvasArray[1, 2]);
            Assert.AreEqual(c, canvasArray[2, 2]);

            Assert.AreNotEqual(c, canvasArray[0, 0]);
            Assert.AreNotEqual(c, canvasArray[0, 1]);
            Assert.AreNotEqual(c, canvasArray[0, 2]);
            Assert.AreNotEqual(c, canvasArray[1, 0]);
            Assert.AreNotEqual(c, canvasArray[2, 0]);
            Assert.AreNotEqual(c, canvasArray[2, 1]);
        }

        [TestMethod]
        public void TestCanvasAddSprite()
        {
            int width = 3;
            int height = 3;
            char c = 'w';

            SpriteEntity line = new Line(
                new Point(2, 1),
                new Point(2, 3),
                c
            );

            Canvas canvas = new Canvas(width, height);
            canvas.AddSprite(line);
            Char[,] canvasArray = canvas.GetCanvasArray();

            Assert.AreEqual(c, canvasArray[2, 1]);
            Assert.AreEqual(c, canvasArray[2, 2]);
            Assert.AreEqual(c, canvasArray[2, 3]);

            Assert.AreNotEqual(c, canvasArray[1, 1]);
            Assert.AreNotEqual(c, canvasArray[1, 2]);
            Assert.AreNotEqual(c, canvasArray[1, 3]);
            Assert.AreNotEqual(c, canvasArray[3, 1]);
            Assert.AreNotEqual(c, canvasArray[3, 2]);
            Assert.AreNotEqual(c, canvasArray[3, 3]);
        }

        [TestMethod]
        public void TestCanvasDraw()
        {
            int width = 3;
            int height = 3;

            StringBuilder sb = new StringBuilder();
            sb.Append("-----").Append(Environment.NewLine);
            sb.Append("|\0\0\0|").Append(Environment.NewLine);
            sb.Append("|\0\0\0|").Append(Environment.NewLine);
            sb.Append("|\0\0\0|").Append(Environment.NewLine);
            sb.Append("-----").Append(Environment.NewLine);

            string expected = sb.ToString();

            Canvas canvas = new Canvas(width, height);
            string actual = canvas.Render();

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void TestCanvasDrawWithSprite()
        {
            int width = 3;
            int height = 3;

            StringBuilder sb = new StringBuilder();
            sb.Append("-----").Append(Environment.NewLine);
            sb.Append("|\0x\0|").Append(Environment.NewLine);
            sb.Append("|\0x\0|").Append(Environment.NewLine);
            sb.Append("|\0x\0|").Append(Environment.NewLine);
            sb.Append("-----").Append(Environment.NewLine);

            string expected = sb.ToString();

            Canvas canvas = new Canvas(width, height);
            SpriteEntity line = new Line(
                new Point(2, 1),
                new Point(2, 3),
                'x'
            );
            canvas.AddSprite(line);

            string actual = canvas.Render();

            Assert.AreEqual(expected, actual);
        }
    }
}
