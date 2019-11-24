using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp;
using System.Collections.Generic;
using DrawingApp.Commands;
using DrawingApp.Sprites;
using DrawingApp.Exceptions;

namespace Testing.Sprites
{
    [TestClass]
    public class BucketTest
    {
        private Canvas Canvas;
        private int X1;
        private int Y1;
        private char C;

        [TestInitialize]
        public void SetupTests()
        {
            Canvas = new Canvas(3, 3);
            X1 = 1;
            Y1 = 2;
            C = 'o';
        }

        [TestMethod]
        public void TestBucketCreateSprite1()
        {
            SpriteCommand command = new BucketCommand(X1, Y1, C);

            Bucket sprite = Bucket.CreateSprite(command, Canvas);

            Assert.AreEqual(X1, sprite.Point1.X);
            Assert.AreEqual(Y1, sprite.Point1.Y);
            Assert.AreEqual(C, sprite.C);
        }

        [TestMethod]
        public void TestBucketCreateSprite2()
        {
            Point point1 = new Point(X1, Y1);
            Bucket sprite = Bucket.CreateSprite(point1, C, Canvas);

            Assert.AreEqual(X1, sprite.Point1.X);
            Assert.AreEqual(Y1, sprite.Point1.Y);
            Assert.AreEqual(C, sprite.C);
        }

        [TestMethod]
        [ExpectedException(typeof(OutOfCanvasBoundsException))]
        public void TestBucketOutOfBoundary()
        {
            int x1 = 1;
            int y1 = 14;

            Point point1 = new Point(x1, y1);
            Bucket sprite = Bucket.CreateSprite(point1, C, Canvas);
        }

        [TestMethod]
        public void TestBucketGetCanvasArrayPoints1()
        {
            Char[,] canvasArray = new Char[5, 5]
            {
                { '-',  '|' ,   '|' ,   '|' ,   '-'},
                { '-',  '\0',   '\0',   '\0',   '-'},
                { '-',  '\0',   'x' ,   'x' ,   '-'},
                { '-',  '\0',   '\0',   'x' ,   '-'},
                { '-',  '|' ,   '|' ,   '|' ,   '-'}
            };

            List<Point> expected = new List<Point>()
            {
                new Point(1,1), new Point(1,2), new Point(1,3),
                new Point(2,1), /*(1,1)*/       /*(2,3)*/
                new Point(3,1), new Point(3,2), /*(3,3)*/
            };

            Point point1 = new Point(X1, Y1);
            Bucket sprite = new Bucket(point1, C, canvasArray);

            List<Point> actual = sprite.GetCanvasArrayPoints();

            AssertHelper.ListsAreEquivalent(expected, actual);
        }

        [TestMethod]
        public void TestBucketGetCanvasArrayPoints2()
        {
            Char[,] canvasArray = new Char[5, 5]
            {
                { '-',  '|' ,   '|' ,   '|' ,   '-'},
                { '-',  '\0',   '\0',   '\0',   '-'},
                { '-',  '\0',   'x' ,   'x' ,   '-'},
                { '-',  '\0',   '\0',   'x' ,   '-'},
                { '-',  '|' ,   '|' ,   '|' ,   '-'}
            };

            List<Point> expected = new List<Point>()
            {
                /*(1,1)*/       /*(1,2)*/       /*(1,3)*/
                /*(2,1)*/       new Point(2,2), new Point(2,3),
                /*(3,1)*        /*(3,2)*/       new Point(3,3)
            };

            Point point1 = new Point(3, 3);
            Bucket sprite = new Bucket(point1, C, canvasArray);

            List<Point> actual = sprite.GetCanvasArrayPoints();

            AssertHelper.ListsAreEquivalent(expected, actual);
        }
    }
}
