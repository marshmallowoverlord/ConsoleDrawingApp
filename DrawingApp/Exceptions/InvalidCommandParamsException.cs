using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Exceptions
{
    public class InvalidCommandParamsException : Exception
    {
        public InvalidCommandParamsException(string message)
        : base(message)
    {
        }

        public InvalidCommandParamsException(string message, Exception inner)
        : base(message, inner)
    {
        }
    }
}
