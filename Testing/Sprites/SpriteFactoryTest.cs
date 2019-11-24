using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DrawingApp;
using DrawingApp.Sprites;
using DrawingApp.Commands;
using DrawingApp.Exceptions;

namespace Testing.Sprites
{
    [TestClass]
    public class SpriteFactoryTest
    {
        private Canvas Canvas;

        [TestInitialize]
        public void SetupTests() {
            Canvas = new Canvas(10, 10);
        }

        [TestMethod]
        public void TestSpriteFactoryLine()
        {
            SpriteCommand command = new LineCommand(1, 5, 1, 3);

            SpriteEntity sprite = SpriteFactory.GetSprite(command, Canvas);

            Assert.IsInstanceOfType(sprite, typeof(Line));
        }

        [TestMethod]
        public void TestSpriteFactoryRectangle()
        {
            SpriteCommand command = new RectangleCommand(1, 5, 1, 3);

            SpriteEntity sprite = SpriteFactory.GetSprite(command, Canvas);

            Assert.IsInstanceOfType(sprite, typeof(Rectangle));
        }

        [TestMethod]
        public void TestSpriteFactoryBucket()
        {
            SpriteCommand command = new BucketCommand(1, 5, 'o');

            SpriteEntity sprite = SpriteFactory.GetSprite(command, Canvas);

            Assert.IsInstanceOfType(sprite, typeof(Bucket));
        }
    }
}
