using DrawingApp.Commands;
using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Sprites
{
    public class Bucket : SpriteEntity
    {
        #region Properties
        public Point Point1;
        public Char C;
        public Char[,] CanvasArray;
        #endregion

        #region Constructors

        public Bucket(
            Point point1,
            Char c,
            Char[,] canvasArray
        )
        {
            this.Point1 = point1;
            this.C = c;
            this.CanvasArray = canvasArray;
        }

        #endregion

        #region Methods
        public override char GetChar()
        {
            return C;    
        }

        public override List<Point> GetCanvasArrayPoints()
        {
            List<Point> result = new List<Point>();

            char oldChar = CanvasArray[Point1.X, Point1.Y];

            int width = CanvasArray.GetLength(0);
            int height = CanvasArray.GetLength(1);

            Stack<Point> stack = new Stack<Point>();
            // canvasMaxtrix is the inner canvas
            // Drawing area is 0 based
            stack.Push(new Point(Point1.X, Point1.Y));

            // Traverse
            while (stack.Count > 0)
            {
                Point currentPoint = stack.Pop();
                int currentX = currentPoint.X;
                int currentY = currentPoint.Y;

                // current point - middle
                if (CanvasArray[currentX, currentY] == oldChar)
                {
                    CanvasArray[currentX, currentY] = C;
                    result.Add(currentPoint);
                }
                // top
                if (currentY - 1 >= 1 && CanvasArray[currentX, currentY - 1] == oldChar)
                {
                    Point point = new Point(currentX, currentY - 1);
                    stack.Push(point);
                }
                // right
                if (currentX + 1 < width - 1 && CanvasArray[currentX + 1, currentY] == oldChar)
                {
                    Point point = new Point(currentX + 1, currentY);
                    stack.Push(point);
                }
                //bottom
                if (currentY + 1 < height - 1 && CanvasArray[currentX, currentY + 1] == oldChar)
                {
                    Point point = new Point(currentX, currentY + 1);
                    stack.Push(point);
                }
                // left
                if (currentX - 1 >= 1 && CanvasArray[currentX - 1, currentY] == oldChar)
                {
                    Point point = new Point(currentX - 1, currentY);
                    stack.Push(point);
                }
            }

            return result;
        }

        public static Bucket CreateSprite(
            Point point1,
            Char c,
            Canvas canvas
        )
        {
            int xBoundary = canvas.Width;
            int yBoundary = canvas.Height;

            if (
                point1.X > xBoundary ||
                point1.Y > yBoundary
            )
            {
                throw new OutOfCanvasBoundsException("Bucket fill point specified must be within the canvas boundary. Canvas size: " + xBoundary + " x " + yBoundary);
            }

            Bucket sprite = new Bucket(
                point1,
                c,
                canvas.GetCanvasArray()
            );

            return sprite;
        }

        public static Bucket CreateSprite(
            SpriteCommand command,
            Canvas canvas
        )
        {
            BucketCommand bucketCommand = (BucketCommand) command;

            return CreateSprite(
                new Point(bucketCommand.X1, bucketCommand.Y1),
                bucketCommand.C,
                canvas
            );
        }

        #endregion
    }
}
