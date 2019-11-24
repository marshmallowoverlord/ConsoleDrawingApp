using DrawingApp.Commands;
using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Sprites
{
    public class Line : SpriteEntity
    {
        #region Constants
        private const char LINE_CHAR = 'x';
        #endregion

        #region Properties
        public Point Point1;
        public Point Point2;
        public Char C;

        #endregion

        #region Constructors

        public Line(
            Point point1,
            Point point2,
            Char c
        )
        {
            this.Point1 = point1;
            this.Point2 = point2;
            this.C = c;
        }

        #endregion

        #region Methods
        public override List<Point> GetCanvasArrayPoints()
        {
            List<Point> points = new List<Point>();

            int x1 = Point1.X;
            int x2 = Point2.X;
            int y1 = Point1.Y;
            int y2 = Point2.Y;

            // Horizontal line
            if (x1 == x2)
            {
                int yMin = Math.Min(y1, y2);
                int yMax = Math.Max(y1, y2);
                for (int i = yMin; i <= yMax; i++)
                {
                    points.Add(new Point(x1, i));
                }
            }
            // Vertical line
            else if (y1 == y2)
            {
                int xMin = Math.Min(x1, x2);
                int xMax = Math.Max(x1, x2);
                for (int i = xMin; i <= xMax; i++)
                {
                    points.Add(new Point(i, y1));
                }
            }

            return points;
        }

        public override Char GetChar()
        {
            return C;
        }

        public static Line CreateSprite(
            Point point1,
            Point point2,
            Canvas canvas
        )
        {
            return CreateSprite(
                LINE_CHAR,
                point1,
                point2,
                canvas    
            );
        }

        public static Line CreateSprite(
            Char c,
            Point point1,
            Point point2,
            Canvas canvas
        )
        {
            int xBoundary = canvas.Width;
            int yBoundary = canvas.Height;

            if (
                point1.X > xBoundary || point2.X > xBoundary ||
                point1.Y > yBoundary || point2.Y > yBoundary
            )
            {
                throw new OutOfCanvasBoundsException("Start and end points specified must be within the canvas boundary. Canvas size: " + xBoundary + " x " + yBoundary);
            }

            Line sprite = new Line(
                point1,
                point2,
                c
            );

            return sprite;
        }

        public static Line CreateSprite(
            SpriteCommand command,
            Canvas canvas
        )
        {
            LineCommand lineCommand = (LineCommand)command;

            return CreateSprite(
                new Point(lineCommand.X1, lineCommand.Y1),
                new Point(lineCommand.X2, lineCommand.Y2),
                canvas
            );
        }

        #endregion
    }
}
