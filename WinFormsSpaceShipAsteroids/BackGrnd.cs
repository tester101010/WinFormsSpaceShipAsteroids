using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    sealed class BackGrnd : BaseObject
    {
        private Bitmap BackGrndImg;

        public BackGrnd(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            BackGrndImg = ResourceTextures.galaxy_png_images;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(BackGrndImg, Pos.X, Pos.Y, 1280, 720);//1280, 720 1500, 900   
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y;// + Dir.Y;

            if (Pos.X < (-Game.Width)) Pos.X = Game.Width;
        }
    }
}
