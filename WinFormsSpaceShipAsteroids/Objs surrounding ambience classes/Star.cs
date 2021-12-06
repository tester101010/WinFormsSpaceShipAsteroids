using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    class Star : BaseObject
    {
        private Bitmap st;

        public Star(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            st = ResourceTextures.kiss;
            Damage = 1;
        }

        public int Damage { get; internal set; }

        //public override void Draw()
        //{
        //    Game.Buffer.Graphics.DrawEllipse(Pens.Gold, Pos.X, Pos.Y=300, Size.Width, Size.Height);
        //    //Game.Buffer.Graphics.DrawLine(Pens.Aqua, Pos.X, Pos.Y, Pos.X+ Size.Width, Pos.Y + Size.Height);
        //    //Game.Buffer.Graphics.DrawLine(Pens.Aqua, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
        //    //base.Draw();
        //}
        public override void Draw()
        {                                                           //*(-Game.Heigth/100)
            Game.Buffer.Graphics.DrawEllipse(Pens.Gold, Pos.X, Pos.Y = Game.Heigth-(Pos.Y), Size.Width, Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.Aqua, Pos.X, Pos.Y, Pos.X+ Size.Width, Pos.Y + Size.Height);
            //Game.Buffer.Graphics.DrawLine(Pens.Aqua, Pos.X + Size.Width, Pos.Y, Pos.X, Pos.Y + Size.Height);
            Game.Buffer.Graphics.DrawImage(st , Pos.X, Pos.Y = Game.Heigth - (Pos.Y), 9, 9);
            //base.Draw();
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y;// + Dir.Y;
            if (Pos.X < -1) Pos.X = Game.Width+5;// -Size.Width;
            if (Pos.X > Game.Width+10) Dir.X = -Dir.X;   // как в base
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;            // как в base
            //if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;  // как в base
            //base.Update();
        }
    }
}
