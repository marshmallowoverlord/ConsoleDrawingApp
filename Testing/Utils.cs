using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp
{
    public class Utils
    {
        public static int FormatPositiveInt(string number)
        {
            int result = -1;

            if (!Int32.TryParse(number, out result) || result <= 0)
            {
                throw new Exception("Number must be positive integer.");
            }

            return result;
        }
    }
}
