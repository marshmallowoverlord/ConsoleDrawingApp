using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class QuitCommand : CommandEntity
    {
        private const string COMMAND_PATTERN = "Q";
        private const string HELP_MSG = "Should quit the program.";

        internal static string GetHelp()
        {
            return COMMAND_PATTERN + " - " + HELP_MSG;
        }

        internal static QuitCommand CreateCommand(
            string[] parameters
        )
        {
            // Validate Mandatory
            if (parameters.Length > 0)
            {
                throw new InvalidCommandParamsException("Received unexpected parameters. No parameters expected.");
            }

            QuitCommand command = new QuitCommand();


            return command;
        }
    }
}
