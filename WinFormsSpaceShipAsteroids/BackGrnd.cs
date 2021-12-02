using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    class BackGrnd : BaseObject
    {
        private Bitmap BackGrndImg;

        public BackGrnd(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            BackGrndImg = ResourceTextures.galaxy_png_images;
        }

        public override void Draw()
        {
            Game.Buffer.Graphics.DrawImage(BackGrndImg, Pos.X, Pos.Y, 1280, 720);//1280, 720 1500, 900
            //Game.Buffer.Graphics.DrawImage(ResourceTextures.galaxy_png_images, Pos.X, Pos.Y, 1280, 720);//1280, 720 1500, 900
            //throw new NotImplementedException();
        }
        public override void Update()
        {
            Pos.X = Pos.X - Dir.X;
            Pos.Y = Pos.Y;// + Dir.Y;
            if (Pos.X < (-1280)) Pos.X = Game.Width;
            //if (Pos.X > Game.Width) Dir.X = -Dir.X;
            //if (Pos.Y < 0) Dir.Y = -Dir.Y;
            //if (Pos.Y > Game.Heigth) Dir.Y = -Dir.Y;
        }
    }
}
