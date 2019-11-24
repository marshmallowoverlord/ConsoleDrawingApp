using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class RectangleCommand : SpriteCommand
    {
        private static readonly Type ThisType = typeof(RectangleCommand);

        private const string COMMAND_PATTERN = "R x1 y1 x2 y2";
        private const string HELP_MSG = "Should create a new rectangle, whose upper left corner is (x1,y1) and lower right corner is (x2,y2). Horizontal and vertical lines will be drawn using the 'x' character.";

        public int X1;
        public int Y1;
        public int X2;
        public int Y2;

        public RectangleCommand(
            int x1,
            int y1,
            int x2,
            int y2
        )
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }

        internal static string GetHelp()
        {
            return COMMAND_PATTERN + " - " + HELP_MSG;
        }

        internal static RectangleCommand CreateCommand(
            string[] parameters
        )
        {
            // Validate Mandatory
            if (parameters.Length != 4)
            {
                throw new InvalidCommandParamsException("Expected 4 parameters but received " + parameters.Length);
            }

            try
            {
                RectangleCommand command = new RectangleCommand(
                    Utils.FormatPositiveInt(parameters[0]),
                    Utils.FormatPositiveInt(parameters[1]),
                    Utils.FormatPositiveInt(parameters[2]),
                    Utils.FormatPositiveInt(parameters[3])
                );

                return command;
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid parameter/s " + String.Join(" ", parameters) + ". \n" + GetHelp(), ex);
            }
        }

    }
}
