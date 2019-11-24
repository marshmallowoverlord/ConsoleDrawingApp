using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class LineCommand : SpriteCommand
    {
        #region Constants
        private static readonly Type ThisType = typeof(LineCommand);

        private const string COMMAND_PATTERN = "L x1 y1 x2 y2";
        private const string HELP_MSG = "Should create a new line from (x1,y1) to (x2,y2). Currently only horizontal or vertical lines are supported. Horizontal and vertical lines will be drawn using the 'x' character.";

        #endregion

        #region Properties
        public int X1;
        public int Y1;
        public int X2;
        public int Y2;
        #endregion

        #region Constructors
        public LineCommand(
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
        #endregion

        #region Methods
        internal static string GetHelp()
        {
            return COMMAND_PATTERN + " - " + HELP_MSG;
        }

        internal static LineCommand CreateCommand(
            string[] parameters
        )
        {
            // Validate Mandatory
            if (parameters.Length != 4)
            {
                throw new InvalidCommandParamsException("Expected 4 parameters but received " + parameters.Length + "\n" + GetHelp());
            }

            if (
                parameters[0] != parameters[2] &&
                parameters[1] != parameters[3]
            )
            {
                throw new InvalidCommandParamsException("Line must be horizontal or vertical. \n" + GetHelp());
            }

            try
            {
                int x1 = Utils.FormatPositiveInt(parameters[0]);
                int y1 = Utils.FormatPositiveInt(parameters[1]);
                int x2 = Utils.FormatPositiveInt(parameters[2]);
                int y2 = Utils.FormatPositiveInt(parameters[3]);

                LineCommand command = new LineCommand(
                    x1,
                    y1,
                    x2,
                    y2
                );

                return command;
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid parameter/s " + String.Join(" ", parameters) + ". \n" + GetHelp(), ex);
            }
        }
        #endregion
    }
}
