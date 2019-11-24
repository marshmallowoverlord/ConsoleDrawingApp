using DrawingApp.Exceptions;
using System;

namespace DrawingApp.Commands
{
    public class CommandFactory
    {
        public CommandFactory (){ }

        public static CommandEntity GetCommand (
            string commandLine
        )
        {
            string cleanedString = System.Text.RegularExpressions.Regex.Replace(commandLine.Trim(), @"\s+", " ");
            string[] split = cleanedString.Split(' ');
            
            int paramcount = split.Length - 1;
            string[] parameters = new string[paramcount];
            Array.Copy(split, 1, parameters, 0, paramcount);

            switch (split[0].ToUpper()) {
                case "Q":
                    return QuitCommand.CreateCommand(parameters);
                case "C":
                    return CanvasCommand.CreateCommand(parameters);
                case "L":
                    return LineCommand.CreateCommand(parameters);
                case "R":
                    return RectangleCommand.CreateCommand(parameters);
                case "B":
                    return BucketCommand.CreateCommand(parameters);
                default:
                    string helpMessage = HelpCommand.CreateCommand().Message;
                    throw new InvalidCommandException("Unknown command \n" + helpMessage);
            }
        }
    }
}
