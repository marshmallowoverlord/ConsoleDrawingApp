using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp.Exceptions;
using DrawingApp;
using DrawingApp.Commands;
using DrawingApp.Sprites;
using System.Collections.Generic;

namespace Testing.Commands
{
    [TestClass]
    public class LineTest
    {
        private Canvas Canvas;
        private char C;

        private int X1;
        private int Y1;
        private int X2;
        private int Y2;

        [TestInitialize]
        public void SetupTests()
        {
            Canvas = new Canvas(10, 10);
            C = 'x';

            X1 = 1;
            Y1 = 5;
            X2 = 1;
            Y2 = 3;
        }

        [TestMethod]
        public void TestLineCreateSprite1()
        {
            SpriteCommand command = new LineCommand(X1, Y1, X2, Y2);

            Line sprite = Line.CreateSprite(command, Canvas);

            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);

            AssertHelper.AssertEqual(point1, sprite.Point1);
            AssertHelper.AssertEqual(point2, sprite.Point2);
            Assert.AreEqual(C, sprite.C);
        }

        [TestMethod]
        public void TestLineCreateSprite2()
        {
            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);
            Line sprite = Line.CreateSprite(point1, point2, Canvas);

            AssertHelper.AssertEqual(point1, sprite.Point1);
            AssertHelper.AssertEqual(point2, sprite.Point2);
            Assert.AreEqual(C, sprite.C);
        }

        [TestMethod]
        public void TestLineCreateSprite3()
        {
            char c = 'w';

            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);
            Line sprite = Line.CreateSprite(c, point1, point2, Canvas);

            AssertHelper.AssertEqual(point1, sprite.Point1);
            AssertHelper.AssertEqual(point2, sprite.Point2);
            Assert.AreEqual(c, sprite.C);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfCanvasBoundsException))]
        public void TestLineOutOfBoundary()
        {
            int x1 = 1;
            int y1 = 14;
            int x2 = 1;
            int y2 = 3;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Line sprite = Line.CreateSprite(point1, point2, Canvas);
        }

        [TestMethod]
        public void TestLineGetChar()
        {
            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);
            Line sprite = new Line(point1, point2, C);

            Char character = sprite.GetChar();

            Assert.AreEqual(C, character);
        }

        [TestMethod]
        public void TestLineGetCanvasArrayPoints()
        {
            List<Point> expected = new List<Point>(){
                new Point(0, 2),
                new Point(0, 3),
                new Point(0, 4)
            };

            Point point1 = new Point(X1, Y1);
            Point point2 = new Point(X2, Y2);
            Line sprite = new Line(point1, point2, C);
            List<Point> actual = sprite.GetCanvasArrayPoints();

            AssertHelper.ListsAreEqual(expected, actual);
        }
    }
}
