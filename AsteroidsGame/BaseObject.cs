using System;
using System.Drawing;

namespace AsteroidsGame
{
    class BaseObject
    {
        protected Point Pos;
        protected Point Dir;
        protected Image Image;


        public BaseObject(Image image, Point pos, Point dir)
        {
            Image = image;
            Pos = pos;
            Dir = dir;

        }

        public virtual void Draw()
        {
            Game.Buffer.Graphics.DrawImage(Image, Pos.X, Pos.Y);
        }

        public virtual void Update()
        {
            Pos.X = Pos.X + Dir.X;
            Pos.Y = Pos.Y + Dir.Y;
            if (Pos.X < 0) Dir.X = -Dir.X;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Height) Dir.Y = -Dir.Y;
        }
    }
}