using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    sealed class Asteroid : BaseObject
    {
        //private int SW = 9;
        //private int SH = 9;

        public int Power { get; set; }
        public int Damage { get; internal set; }

        private Bitmap aster;

        public Asteroid(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            Power = 1;
            Damage = 10;
            aster = ResourceTextures.asteroids1;
        }

        public override void Draw()
        {
            //Game.Buffer.Graphics.FillEllipse(Brushes.White, Pos.X, Pos.Y,22, 11);
            //Game.Buffer.Graphics.DrawLine(Pens.AntiqueWhite, Pos.X, Pos.Y, Pos.X + SW, Pos.Y + SH);
            //Game.Buffer.Graphics.DrawLine(Pens.Azure, Pos.X + SW, Pos.Y, Pos.X, Pos.Y + SH);
            Game.Buffer.Graphics.DrawImage(aster, Pos.X, Pos.Y , 15, 15);
            //Game.Buffer.Graphics.DrawImage(ResourceTextures.asteroids1, Pos.X, Pos.Y , 15, 15);
        }

        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            //Pos.Y = Pos.Y;// + Dir.Y;
            if (Pos.X < (-9)) Pos.X = Game.Width;
            if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;
        }
    }
}
