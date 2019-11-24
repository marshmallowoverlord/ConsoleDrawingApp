using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    public class Point
    {
        #region Properties

        // Denotes the horizontal position
        public int X;

        // Denotes the vertical position
        public int Y;

        #endregion

        #region Constructors

        public Point (){}

        public Point(
            int x,
            int y
        )
        {
            this.X = x;
            this.Y = y;
        }

        #endregion

        public static void DrawAt(char c, int x, int y)
        {
            try
            {
                System.Console.SetCursorPosition(x, y);
                System.Console.Write(c);
            }
            catch (Exception ex)
            {
                System.Console.WriteLine("Error occurred while drawing.");
                System.Console.WriteLine(ex.Message);
            }
        }
    }
}
