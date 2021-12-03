using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    class Bullet : BaseObject
    {
        private int _dir;

        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            _dir = dir.X;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
            //throw new NotImplementedException();
        }

        public override void Update()
        {
            Pos.X = Pos.X + _dir;
        }
    }
}
