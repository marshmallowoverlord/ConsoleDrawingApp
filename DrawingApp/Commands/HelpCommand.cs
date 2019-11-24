using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Commands
{
    public class HelpCommand : CommandEntity
    {
        public string Message;

        public HelpCommand(
            string message
        )
        {
            this.Message = message;
        }

        internal static HelpCommand CreateCommand()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(CanvasCommand.GetHelp());
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(LineCommand.GetHelp());
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(RectangleCommand.GetHelp());
            sb.Append(Environment.NewLine);
            sb.Append(Environment.NewLine);
            sb.Append(QuitCommand.GetHelp());

            HelpCommand command = new HelpCommand(sb.ToString());

            return command;
        }
    }
}
