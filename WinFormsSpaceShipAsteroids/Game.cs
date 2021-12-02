using System;
//using System.Media;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsSpaceShipAsteroids
{
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Heigth { get; set; }


        private static BaseObject[] _objs;//В начале программы массив должен остаться static
        private static Asteroid[] _asteroids;
        //private static Rocks[] _rocks;
        //private static Comet[] _comets;
        //public static Healing[] _healings;
        private static Star[] _stars;
        private static BackGrnd[] _backGrnds;
        private static int _backGrndsScrollSpeed=1;
        private static Bullet _bullet;
                                //private static SoundPlayer _s1;


        public Game()
        {

        }

        #region Region init & CreateTimer_tick
        internal static void Init(Form form)
        {
            Graphics g;
            _context = BufferedGraphicsManager.Current;
            g = form.CreateGraphics();
            Width = form.ClientSize.Width;
            Heigth = form.ClientSize.Height;
            Buffer = _context.Allocate(g, new Rectangle(0, 0, Width, Heigth));
            Load();
            Timer timer = new Timer { Interval = 20 };
            CreateTimer(timer);

        }

        private static void CreateTimer(Timer timer)
        {
            timer.Start();
            timer.Tick += Timer_Tick;
        }

        private static void Timer_Tick(object sender, EventArgs e)
        {
            Draw();
            Update();
        }
        #endregion

        public static void Load()
        {
            Random rnd = new Random();

            #region V2
            //int spaceObjsCount = 30;
            //int boCount = rnd.Next(0, spaceObjsCount);
            //int stCount = rnd.Next(0, spaceObjsCount - boCount);
            //BaseObject[] _objs = new BaseObject[boCount];
            //Star[] _stars = new Star[stCount];

            #endregion
            _backGrnds = new BackGrnd[2];
            _backGrnds[0] = new BackGrnd(new Point(Game.Width,0), new Point(_backGrndsScrollSpeed, 0),new Size(1,1));
            _backGrnds[1] = new BackGrnd(new Point(0,0), new Point(_backGrndsScrollSpeed, 0),new Size(1,1));

            int _speedSpaceObjs = 9;
            int rndMin = 3;
            int rndMax = 12;
            //int arrLength = 9;
            int rMinMax = rnd.Next(rndMin, rndMax);
            int[] rndObj = new int[10];

            _objs = new BaseObject[6];
            _stars = new Star[20];
            _asteroids = new Asteroid[4];

            _bullet = new Bullet(new Point(0,200), new Point(0, 0),new Size(14,22));

            //for (int i = 0; i < arrLength; i++)
            //{
            //    rndObj[i] = rnd.Next(rndMin, rndMax);
            //    //Console.Write($" {rndObj[i]}" + ",");
            //}


            #region V1
            for (int i = 0; i < _objs.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point( -i*r, -i*r )
                _objs[i] = new Comet(new Point(Width, rnd.Next(1,Game.Heigth)), new Point((rSp /3)*2, 0), new Size(1, 1));
            }

            for (int i = 0; i < _stars.Length; i++)            //       ((i)+(r+i*i), 0),
            {                                                   //, new Point(-(i/r) , 0),
                _stars[i] = new Star(new Point(Width - 5, i * 18), new Point((_speedSpaceObjs * _speedSpaceObjs - ((i * i) / (2 * _speedSpaceObjs - 12))) / 3, 0), new Size(3, 3));
                //_objs[i] = new BaseObject(new Point(Width, i* 10* r), new Point( -i*r, -i*r ), new Size(r*2, r));
                //(new Point(1260, _random.Next(0, 500)), new Point(11 - i, 0), new Size(33, 33));
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point(_speedSpaceObjs, 0)||(-rSp / 5, rSp)
                _asteroids[i] = new Asteroid(new Point(Width, rnd.Next(1, Game.Heigth)), new Point(rSp/2 , 0), new Size(rSp * 5, rSp * 5));
            }
            #endregion

            #region V3
            //int spaceObjsCount = 30;
            //List<BaseObject> _obls = new List<BaseObject>();
            //int[] counter = new int[2];
            //for (int i = 0; i < spaceObjsCount; i++)
            //{
            //    switch (rnd.Next(0, counter.Length))
            //    {
            //       // case 0: _obls.Add(new Comet(new Point(Width, 1 + i * 10 * r), new Point(_objs.Length - i, 0), new Size(r * 2, r))); counter[0]++; break;
            //        case 0: _obls.Add(new Star(new Point(Width - 5, i * 18), new Point((_speedSpaceObjs * _speedSpaceObjs - ((i * i) / (2 * _speedSpaceObjs - 12))) / 3, 0), new Size(3, 3))); counter[0]++; break;
            //        default: _obls.Add(new Comet(new Point(Width, 1 + i * 10 * r), new Point(_objs.Length - i, 0), new Size(r * 2, r))); counter[1]++; break;
            //    }
            //}
            #endregion
        }

        public static void Update()
        {
            _backGrnds[0]?.Update();
            _backGrnds[1]?.Update();

            //Random rnd = new Random();
            //int r = rnd.Next(5, 20);
            foreach (BaseObject obj in _objs)
            {
                obj?.Update();
                if (obj.Collision(_bullet))
                {
                    //Game.Buffer.Graphics.DrawImage(ResourceTextures.asteroids1, Pos.X, Pos.Y , 15, 15);
                    //System.Media.SoundPlayer = ResourceTextures.Windows_Hardware_Remove;  //Hand.Play();
                    //System.Media.SystemSounds.Hand.Play();
                    Console.Beep( 300,  80);
                }
            }
            foreach (Star s in _stars)
            {
                s?.Update();
                if (s.Collision(_bullet))
                {
                    //System.Media.SystemSounds.Hand.Play();
                    Console.Beep(300, 30);
                }
            }
            foreach (Asteroid a in _asteroids)
            {
                a?.Update();
                if (a.Collision(_bullet))
                {
                    //System.Media.SystemSounds.Hand.Play();
                    Console.Beep( 300,  50);
                }
            }
            _bullet?.Update();
        }


        internal static void Draw()
        {
            //int w = 200;
            //int h = 200;
            Buffer.Graphics.Clear(Color.Empty);
            _backGrnds[0]?.Draw();
            _backGrnds[1]?.Draw();

            foreach (BaseObject obj in _objs) obj?.Draw();
            foreach (Star s in _stars) s?.Draw();
            foreach (Asteroid a in _asteroids) a?.Draw();
            //for (int i = _stars.Length - 1; i > 0; i--)
            //{
            //    _stars[i]?.Draw();
            //    //_stars[i]?.Draw();
            //}
            _bullet?.Draw();
            Buffer.Render();
            //throw new NotImplementedException();
        }
    }
}
