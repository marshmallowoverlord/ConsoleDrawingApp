using DrawingApp.Commands;
using DrawingApp.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Sprites
{
    public class SpriteFactory
    {
        public SpriteFactory()
        {

        }

        public static SpriteEntity GetSprite(
            SpriteCommand command,
            Canvas canvas
        )
        {
            string commandType = command.GetType().Name;
            switch (commandType.ToUpper())
            {
                case "LINECOMMAND":
                    return Line.CreateSprite(command, canvas);
                case "RECTANGLECOMMAND":
                    return Rectangle.CreateSprite(command, canvas);
                case "BUCKETCOMMAND":
                    return Bucket.CreateSprite(command, canvas);
                default:
                    throw new InvalidCommandException("unknown command");
            }
        }
    }
}
