using System.Drawing;

namespace WinFormsSpaceShipAsteroids
{
    internal class Healing : BaseObject
    {

        private Bitmap heal;

        public Healing(Point pos, Point dir, Size size) : base(pos, dir, size)
        {
            heal = ResourceTextures.Health;
            Heal = 30;
        }

        public int Heal { get; internal set; }

        public override void Draw()
        {
            //Game.Buffer.Graphics.DrawEllipse(Pens.Gold,Pos.X,Pos.Y,Size.Width,Size.Height);
            Game.Buffer.Graphics.DrawImage(heal, Pos.X, Pos.Y, 22, 22);
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
    }
}