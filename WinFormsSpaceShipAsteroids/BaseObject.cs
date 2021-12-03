using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsSpaceShipAsteroids
{
    public delegate void Message();

    public abstract class BaseObject : ICollision
    {
        protected Point Pos;
        protected Point Dir;
        protected Size Size;

        public BaseObject(Point pos, Point dir, Size size)
        {
            Pos = pos;
            Dir = dir;
            Size = size;
        }

        public abstract void Draw();

        public abstract void Update();

        //public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
        public Rectangle Rect => new Rectangle(Pos,Size);//throw new NotImplementedException();
        //public Rectangle Rect => Rectangle(); //throw new NotImplementedException();

        //public Rectangle Rect
        //{
        //    get
        //    {
        //        return new Rectangle(Pos, Size);
        //    }
        //}

        public virtual bool Collision(ICollision obj)
        {
            //try
            //{
            //    return obj.Rect.IntersectsWith(Rect);

            //}

            //catch (NullReferenceException)
            //{
            //    Console.WriteLine("ArgumentNullException"); return false;
            //}

            //finally
            //{
            //    // Использование блока finally гарантирует, что набор операторов будет
            //    //выполняться всегда, независимо от того, возникло исключение любого типа или нет)
            //    new Rectangle(100, 100, 1, 1);
            //}

            return obj.Rect.IntersectsWith(Rect);
        }
    }
}
