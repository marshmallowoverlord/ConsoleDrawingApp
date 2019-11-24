using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Exceptions
{
    public class InvalidCommandException : Exception
    {
        public InvalidCommandException(string message)
        : base(message)
    {
        }

        public InvalidCommandException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
