using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Exceptions
{
    public class OutOfCanvasBoundsException : Exception
    {
        public OutOfCanvasBoundsException(string message)
        : base(message)
    {
        }

        public OutOfCanvasBoundsException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
