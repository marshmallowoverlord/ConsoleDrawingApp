using DrawingApp.Commands;
using DrawingApp.Sprites;
using System;

namespace DrawingApp
{
    public class Program
    {
        private static Canvas Canvas;

        public static void Main(string[] args)
        {
            while (true)
            {
                System.Console.Write("enter command: ");
                string input = System.Console.ReadLine();

                ProcessInput(input);
            }
        }

        private static void ProcessInput(string input)
        {
            if (!string.IsNullOrWhiteSpace(input))
            {
                try
                {
                    CommandEntity command = CommandFactory.GetCommand(input);

                    if (command is CanvasCommand)
                    {
                        Canvas = Canvas.CreateCanvas(command);
                    }
                    else if (command is SpriteCommand)
                    {
                        if (Canvas != null)
                        {
                            SpriteEntity sprite = SpriteFactory.GetSprite((SpriteCommand)command, Canvas);
                            Canvas.AddSprite(sprite);
                        }
                        else
                        {
                            throw new Exception("No Canvas found. Please create a new canvas before adding sprites.");
                        }
                    }
                    else if (command is QuitCommand)
                    {
                        Environment.Exit(0);
                    }

                    if (Canvas != null)
                    {
                        Draw(Canvas);
                    }
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
            }
        }

        private static void Draw(Canvas canvas)
        {
            string stringToDraw = canvas.Render();
            Console.WriteLine(stringToDraw);
        }
    }
}
