using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class BucketCommand : SpriteCommand
    {
        private static readonly Type ThisType = typeof(BucketCommand);

        private const string COMMAND_PATTERN = "B x y c";
        private const string HELP_MSG = "Should fill the entire area connected to (x,y) with 'colour' c. The behaviour of this is the same as that of the 'bucket fill' tool in paint programs.";

        public int X1;
        public int Y1;
        public char C;

        public BucketCommand(
            int x1,
            int y1,
            char c
        )
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.C = c;
        }

        internal static string GetHelp()
        {
            return COMMAND_PATTERN + " - " + HELP_MSG;
        }

        internal static BucketCommand CreateCommand(
            string[] parameters
        )
        {
            // Validate Mandatory
            if (parameters.Length != 3)
            {
                throw new InvalidCommandParamsException("Expected 3 parameters but received " + parameters.Length + "\n" + GetHelp());
            }
            int xPos = -1;
            int yPos = -1;

            try
            {
                xPos = Utils.FormatPositiveInt(parameters[0]);
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid x position: " + parameters[0] + ".\n" + GetHelp(), ex);
            }

            try
            {
                yPos = Utils.FormatPositiveInt(parameters[1]);
            }
            catch (Exception ex)
            {
                throw new InvalidCommandParamsException("Invalid y position: " + parameters[1] + ".\n" + GetHelp(), ex);
            }

            char[] cArray = parameters[2].ToCharArray();
            if (cArray.Length > 1)
            {
                throw new InvalidCommandParamsException("Expected fill charcter parameter to be a single letter. Received: " + parameters[2] + "\n" + GetHelp());
            }

            BucketCommand command = new BucketCommand(
                xPos,
                yPos,
                cArray[0]
            );

            return command;
        }

    }
}
