﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    class Bullet : BaseObject
    {
        public Bullet(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawEllipse(Pens.OrangeRed, Pos.X, Pos.Y, Size.Width, Size.Height);
            //throw new NotImplementedException();
        }

        public override void Update()
        {
            Pos.X = Pos.X + 3;
        }

    }
}