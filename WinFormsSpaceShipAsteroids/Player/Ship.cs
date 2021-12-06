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
        private static int _bulletSpeed = 33;
        private static int _bulletHeigth = 33;
        private static int _bulletWidth = 14;

        private static int _shipWidth = 100;
        private static int _shipHeigth = 50;

        public int Energy => _energy;

        public Bullet Bullet { get;  set; }

        public static event Message MessageDie;

        public Ship(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            //_plImg = ResourceTextures.Spaceship_480_270;
            _plImg = ResourceTextures.Spaceship_480_270;
        }

        private Bitmap _plImg;

        public void ShootBullet()
        {
            Sound.shotSound.Play();
            Bullet = new Bullet(new Point(Pos.X + Size.Width,Pos.Y + Size.Height/2 - _bulletHeigth/2), new Point(_bulletSpeed, 0), new Size(_bulletWidth, _bulletHeigth));
        }

        public void EnergyLow(int n)
        {
            _energy -= n;
        }

        public void EnergyHi(int n)
        {
            _energy += n;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(_plImg, Pos.X, Pos.Y, _shipWidth, _shipHeigth);
        }

        public override void Update()
        {
            //throw new NotImplementedException();
        }

        public void Left()
        {
            //  Pos.X = Pos.X - Dir.X;
            if (Pos.X > 0) Pos.X = Pos.X - Dir.X;
        }
        public void Right()
        {
            // Pos.X = Pos.X + Dir.X;
            if (Pos.X + Size.Width < Game.Width) Pos.X = Pos.X + Dir.X;
        }
        public void Up()
        {
            if (Pos.Y + Size.Height - 33 > 0) Pos.Y = Pos.Y - Dir.Y;
        }
        public void Down()
        {
            if (Pos.Y + Size.Height + 9 < Game.Heigth) Pos.Y = Pos.Y + Dir.Y;
        }

        public void Die()
        {
            MessageDie?.Invoke();
        }

        internal void BulletDestroy()
        {
            Bullet = null;
        }
    }
}
