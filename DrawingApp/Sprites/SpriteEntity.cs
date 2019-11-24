using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Sprites
{
    public abstract class SpriteEntity : DrawableEntity
    {
        public abstract Char GetChar();

        public abstract List<Point> GetCanvasArrayPoints();
    }
}
