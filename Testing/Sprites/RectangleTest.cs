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
    public class RectangleTest
    {
        private Canvas Canvas;
        private Line Top;
        private Line Right;
        private Line Bottom;
        private Line Left;

        private int X1 = 1;
        private int Y1 = 5;
        private int X2 = 1;
        private int Y2 = 3;
        private char C = 'x';

        [TestInitialize]
        public void SetupTests()
        {
            Canvas = new Canvas(10, 10);
            char c = 'x';

            Top = new Line(new Point(X1, Y1), new Point(X2, Y1), c);
            Right = new Line(new Point(X2, Y1), new Point(X2, Y2), c);
            Bottom = new Line(new Point(X2, Y2), new Point(X1, Y2), c);
            Left = new Line(new Point(X1, Y2), new Point(X1, Y1), c);
        }

        [TestMethod]
        public void TestRectangleCreateSprite1()
        {
            SpriteCommand command = new RectangleCommand(X1, Y1, X2, Y2);
            Rectangle sprite = Rectangle.CreateSprite(command, Canvas);

            AssertHelper.AssertEqual(Top, sprite.Top);
            AssertHelper.AssertEqual(Right, sprite.Right);
            AssertHelper.AssertEqual(Bottom, sprite.Bottom);
            AssertHelper.AssertEqual(Left, sprite.Left);
        }

        [TestMethod]
        public void TestRectangleCreateSprite2()
        {
            SpriteCommand command = new RectangleCommand(X1, Y1, X2, Y2);
            Rectangle sprite = Rectangle.CreateSprite(
                new Point(X1, Y1),
                new Point(X2, Y2),
                Canvas
            );

            AssertHelper.AssertEqual(Top, sprite.Top);
            AssertHelper.AssertEqual(Right, sprite.Right);
            AssertHelper.AssertEqual(Bottom, sprite.Bottom);
            AssertHelper.AssertEqual(Left, sprite.Left);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfCanvasBoundsException))]
        public void TestRectangleOutOfBoundary()
        {
            int x1 = 1;
            int y1 = 14;
            int x2 = 1;
            int y2 = 3;

            Point point1 = new Point(x1, y1);
            Point point2 = new Point(x2, y2);
            Rectangle sprite = Rectangle.CreateSprite(point1, point2, Canvas);
        }

        [TestMethod]
        public void TestRectangleGetChar()
        {
            Rectangle sprite = new Rectangle(Top, Right, Bottom, Left);

            Char character = sprite.GetChar();

            Assert.AreEqual(C, character);
        }

        [TestMethod]
        public void TestRectangleGetCanvasArrayPoints()
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
