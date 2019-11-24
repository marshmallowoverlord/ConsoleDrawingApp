using DrawingApp.Commands;
using DrawingApp.Sprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    public class Canvas: DrawableEntity
    {
        #region Constants
        private const char H_BORDER = '-';
        private const char V_BORDER = '|';
        #endregion

        #region Properties

        public int Width;
        public int Height;
        private Char[,] CanvasArray;

        #endregion

        #region Constructors
        public Canvas(
            int width,
            int height
        )
        {
            this.Width = width;
            this.Height = height;

            CreateCanvasArray();
        }

        private void CreateCanvasArray()
        {
            this.CanvasArray = new Char[Width + 2, Height + 2];

            // Draw outer canvas
            for (int i = 0; i < Width + 2; i++)
            {
                // Top border
                CanvasArray[i, 0] = H_BORDER;
                // Bottom Border
                CanvasArray[i, Height + 1] = H_BORDER;
            }

            for (int i = 0; i < Height; i++)
            {
                // Left Border
                CanvasArray[0, i + 1] = V_BORDER;
                // Rigth Border
                CanvasArray[Width + 1, i + 1] = V_BORDER;
            }
        }
        #endregion

        #region Methods
        private void UpdateCanvasArray(
            List<Point> points,
            Char c
        )
        {
            Char[,] matrix = CanvasArray;

            foreach(Point point in points)
            {
                matrix[point.X, point.Y] = c;
            }

            CanvasArray = matrix;
        }

        public Char[,] GetCanvasArray()
        {
            return CanvasArray;
        }

        internal void AddSprite (
            SpriteEntity sprite    
        )
        {
            List<Point> spritePoints = sprite.GetCanvasArrayPoints();

            UpdateCanvasArray(spritePoints, sprite.GetChar());
        }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();

            for (int y = 0; y < CanvasArray.GetLength(1); y++)
            {
                for (int x = 0; x < CanvasArray.GetLength(0); x++)
                {
                    sb.Append(CanvasArray[x, y]);
                }
                sb.Append(Environment.NewLine);
            }

            return sb.ToString();
        }

        //public void DrawAt ()
        //{
        //    if (Width > 0 && Height > 0)
        //    {
        //        int origX = Console.CursorLeft;
        //        int origY = Console.CursorTop;
        //        int endX = origX + Width + 2;
        //        int endY = origY + Height + 2;
                
        //        // Draw outer canvas
        //        for (int i = 0; i < Width + 2; i++)
        //        {
        //            // Top border
        //            Point.DrawAt(H_BORDER, origX + i, origY);
        //            // Bottom Border
        //            Point.DrawAt(H_BORDER, origX + i, origY + Height + 1);
        //        }

        //        for (int i = 0; i < Height; i++)
        //        {
        //            // Left Border
        //            Point.DrawAt(V_BORDER, origX, origY + i + 1);
        //            // Rigth Border
        //            Point.DrawAt(V_BORDER, origX + Width + 2, origY + i + 1);
        //        }

        //        // Draw inner canvas
        //        for (int x = 0; x < Width; x++)
        //        {
        //            for(int y = 0; y < Height; y++)
        //            {
        //                if (CanvasArray[x,y] != '\0')
        //                {
        //                    Point.DrawAt(CanvasArray[x, y], origX + x + 1, origY + y + 1);
        //                }
        //            }
        //        }

        //        // reset the cursor to end of last line
        //        Console.SetCursorPosition(endX, endY);
        //    }
        //    else
        //    {
        //        throw new Exception("Width and Height must be positive integers. Width: " + Width + " x Height: " + Height + " is not valid. Please specify a valid width and height.");
        //    }
        //}

        #endregion

        public static Canvas CreateCanvas(
            CommandEntity command
        )
        {
            CanvasCommand canvasCommand = (CanvasCommand)command;

            return new Canvas(
                canvasCommand.Width,
                canvasCommand.Height
            );
        }
    }
}
