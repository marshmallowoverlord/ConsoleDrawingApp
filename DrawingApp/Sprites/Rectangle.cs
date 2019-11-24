using DrawingApp.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Sprites
{
    public class Rectangle : SpriteEntity
    {
        #region Constants
        private const char RECTANGLE_CHAR = 'x';
        #endregion

        #region Properties

        public Line Top;
        public Line Right;
        public Line Bottom;
        public Line Left;

        #endregion

        #region Constructors

        public Rectangle(
            Line top,
            Line right,
            Line Bottom,
            Line left
        )
        {
            this.Top = top;
            this.Right = right;
            this.Bottom = Bottom;
            this.Left = left;
        }

        #endregion

        #region Methods
        public override char GetChar()
        {
            return RECTANGLE_CHAR;
        }

        public override List<Point> GetCanvasArrayPoints()
        {
            List<Point> result = new List<Point>();
            result.AddRange(Top.GetCanvasArrayPoints());
            result.AddRange(Right.GetCanvasArrayPoints());
            result.AddRange(Bottom.GetCanvasArrayPoints());
            result.AddRange(Left.GetCanvasArrayPoints());

            return result;
        }

        public static Rectangle CreateSprite(
            Point point1,
            Point point2,
            Canvas canvas
        )
        {
            int x1 = point1.X;
            int x2 = point2.X;
            int y1 = point1.Y;
            int y2 = point2.Y;
            
            Line top = Line.CreateSprite(
                RECTANGLE_CHAR,
                point1,
                new Point(x2, y1),
                canvas
            );

            Line right = Line.CreateSprite(
                RECTANGLE_CHAR,
                new Point(x2, y1),
                point2,
                canvas
            );

            Line bottom = Line.CreateSprite(
                RECTANGLE_CHAR,
                point2,
                new Point (x1, y2),
                canvas
            );

            Line left = Line.CreateSprite(
                RECTANGLE_CHAR,
                new Point(x1, y2),
                point1,
                canvas
            );

            Rectangle sprite = new Rectangle(
                top,
                right,
                bottom,
                left
            );

            return sprite;
        }

        public static Rectangle CreateSprite(
            CommandEntity command,
            Canvas canvas
        )
        {
            RectangleCommand lineCommand = (RectangleCommand) command;

            return CreateSprite(
                new Point(lineCommand.X1, lineCommand.Y1),
                new Point(lineCommand.X2, lineCommand.Y2),
                canvas
            );
        }
        #endregion
    }
}
