using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    abstract class BaseObject: ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        protected BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();
        //{
        ////Game.Buffer.Graphics.DrawEllipse(Pens.Gold,Pos.X,Pos.Y,Size.Width,Size.Height);
        //Game.Buffer.Graphics.DrawImage(ResourceTextures.asteroids1, Pos.X, Pos.Y, 25, 25);
        //}

        public abstract void Update();
        //{
            //Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y;// + Dir.Y;
            //if (Pos.X < 0) Pos.X =  Game.Width;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;
       //}

        public Rectangle Rect => new Rectangle(Pos, Size);//throw new NotImplementedException();

        public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);//throw new NotImplementedException();
    }
}
