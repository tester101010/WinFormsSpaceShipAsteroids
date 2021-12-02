using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    class Ship : BaseObject
    {
        private int _energy = 100;
        public int Energy => _energy;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _plImg = ResourceTextures.Spaceship_480_270;
        }

        private Bitmap _plImg;

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_plImg, Pos.X, Pos.Y, 100, 50);
        }

        public override void Update()
        {
            throw new NotImplementedException();
        }

        public void Left()
        {
            //  Pos.X = Pos.X - Dir.X;
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }
        public void Right()
        {
            // Pos.X = Pos.X + Dir.X;
            if (Pos.X < Game.Width) Pos.X = Pos.X + Dir.X;
        }
        public void Up()
        {
            if (Pos.Y < Game.Heigth) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y < Game.Heigth) Pos.Y = Pos.Y + Dir.Y;
        }
    }
}
