using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class CanvasCommand : CommandEntity
    {
        private const string COMMAND_PATTERN = "C w h";
        private const string HELP_MSG = "Should create a new canvas of width w and height h.";

        public int Width;
        public int Height;

        public CanvasCommand (
            int width,
            int height
        )
        {
            this.Width = width;
            this.Height = height;
        }

        internal static string GetHelp()
        {
            return COMMAND_PATTERN + " - " + HELP_MSG;
        }

        internal static CanvasCommand CreateCommand(
            string[] parameters
        )
        {
            CanvasCommand command = null;

            // Validate Mandatory
            if (parameters.Length != 2)
            {
                throw new InvalidCommandParamsException("Expected 2 parameters but received " + parameters.Length + "\n" + GetHelp());
            }

            int width = -1;
            int height = -1;

            try
            {
                width = Utils.FormatPositiveInt(parameters[0]);
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid width: " + parameters[0] + ".\n" + GetHelp() , ex);
            }

            try
            {
                height = Utils.FormatPositiveInt(parameters[1]);
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid height: " + parameters[1] + ". \n" + GetHelp(), ex);
            }

            command = new CanvasCommand(
                width,
                height
            );

            return command;
        }
    }
}
