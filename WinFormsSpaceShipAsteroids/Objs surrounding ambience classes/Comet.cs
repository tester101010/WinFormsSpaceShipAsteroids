using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    internal class Comet : BaseObject
    {
        private Bitmap cmt;

        public Comet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            cmt = ResourceTextures.fire_fall;
            Damage = 30;
        }

        public int Damage { get; internal set; }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.Gold,Pos.X,Pos.Y,Size.Width,Size.Height);
            Game.Buffer.Graphics.DrawImage(cmt, Pos.X, Pos.Y, 90, 20);
            //Game.Buffer.Graphics.DrawImage(ResourceTextures.fire_fall, Pos.X, Pos.Y, 90, 20);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y;// + Dir.Y;
            if (Pos.X < (-90)) Pos.X = Game.Width;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            if (Pos.Y < 0) Dir.Y = -Dir.Y;
            if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;
        }
        //public override bool Collision(ICollision obj)
        //{
        //    return obj.Rect.IntersectsWith(Rect);
        //    //return obj.Rect.IntersectsWith(Rect);
        //}
    }
}
