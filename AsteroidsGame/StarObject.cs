using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidsGame
{
    internal class StarObject : BaseObject
    {
        public StarObject(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image.FromFile("Assets/512x512bb.png"), Pos.X, Pos.Y);
        }
    }
}
