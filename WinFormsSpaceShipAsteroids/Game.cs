using System;
using System.Media;
using System.Drawing;
using WinFormsSpaceShipAsteroids;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//ToDo: 
// 1) пофиксить медиа файлы и папки
// 2) сделать паузу и выход из приложения
// 3) сделать звуки и музыку в игре
// 4) сделать анимацию взрывов и огонь двигателя коробля 
//  ) 
// LAST) сделать меню паузы и настроек (GUI)

namespace WinFormsSpaceShipAsteroids
{
    //static class Sound
    //{
    //    public static System.Media.SoundPlayer screamSound = new System.Media.SoundPlayer("scream.wav");
    //    public static System.Media.SoundPlayer shotSound = new System.Media.SoundPlayer("shot.wav");
    //    public static System.Media.SoundPlayer shipDamageSound = new System.Media.SoundPlayer("dmg.wav");
    //    public static System.Media.SoundPlayer endSound = new System.Media.SoundPlayer("end.wav");
    //    public static System.Media.SoundPlayer metaHit = new System.Media.SoundPlayer("metalhit.wav");
    //    public static System.Media.SoundPlayer heal = new System.Media.SoundPlayer("heal.wav");
    //    public static MediaPlayer music = new MediaPlayer();
    //}
    class Game
    {
        private static BufferedGraphicsContext _context;
        public static BufferedGraphics Buffer;

        public static int Width { get; set; }
        public static int Heigth { get; set; }

        private static int _shipHeigth = 50;
        private static int _shipWidth = 100;

        //private static BaseObject[] _objs;//В начале программы массив должен остаться static
        //private static Rocks[] _rocks;
        private static Asteroid[] _asteroids;
        private static Comet[] _comets;
        private static Healing[] _healings;
        private static Star[] _stars;

        private static BackGrnd[] _backGrnds;
        private static int _backGrndsScrollSpeed = 1;

        //private static Bullet _bullet; // ToDo
        //private static int _bulletSpeed = 33;
        //private static int _bulletHeigth = 33;
        //private static int _bulletWidth = 14;
        //private static SoundPlayer _s1 = "cow.wav";
        private static SoundPlayer player;
        private const string UriString = "drama.wav";

        Random rnd = new Random();
        int rndMin = 3;
        int rndMax = 12;
        //int arrLength = 9;
        int[] rndObj = new int[10];


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
            form.KeyDown += Form_KeyDown;
            Ship.MessageDie += Finish;
            CreateTimer(_timer);
            Load();
        }

        private static Timer _timer = new Timer { Interval = 20 };

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
            _backGrnds[0] = new BackGrnd(new Point(Game.Width, 0), new Point(_backGrndsScrollSpeed, 0), new Size(1, 1));
            _backGrnds[1] = new BackGrnd(new Point(0, 0), new Point(_backGrndsScrollSpeed, 0), new Size(1, 1));

            int _speedSpaceObjs = 9;


            //_objs = new BaseObject[6];
            _comets = new Comet[3];
            _stars = new Star[20];
            _asteroids = new Asteroid[4];
            _healings = new Healing[4];

            // Sound.SFXHeal.PlayLooping();//music.Play();
            //Sound.music.Open(new Uri(UriString, UriKind.Relative)); // загрузка фоновой музыки
            InitializeSound();
            // ToDo нельзя убрать _bullet = new Bullet, выбрасывает исключение BaseObject 
            // public bool Collision(ICollision o) => o.Rect.IntersectsWith(this.Rect);
            //_ship.Bullet  = new Bullet(new Point(0, Width - _bulletWidth), new Point(_bulletSpeed, 0), new Size(_bulletWidth, _bulletHeigth));

            //for (int i = 0; i < arrLength; i++)
            //{
            //    rndObj[i] = rnd.Next(rndMin, rndMax);
            //    //Console.Write($" {rndObj[i]}" + ",");
            //}


            #region V1
            for (int i = 0; i < _comets.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point( -i*r, -i*r )
                _comets[i] = new Comet(new Point(Width, rnd.Next(1, Game.Heigth)), new Point((rSp / 3) * 2, 0), new Size(1, 1));
            }
            // ((ICollision)Comet)comets.

            for (int i = 0; i < _stars.Length; i++)            //       ((i)+(r+i*i), 0),
            {                                                   //, new Point(-(i/r) , 0),
                _stars[i] = new Star(new Point(Width - 5, i * 18), new Point((_speedSpaceObjs * _speedSpaceObjs - ((i * i) / (2 * _speedSpaceObjs - 12))) / 3, 0), new Size(3, 3));
                //_objs[i] = new BaseObject(new Point(Width, i* 10* r), new Point( -i*r, -i*r ), new Size(r*2, r));
                //(new Point(1260, _random.Next(0, 500)), new Point(11 - i, 0), new Size(33, 33));
            }

            for (int i = 0; i < _asteroids.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point(_speedSpaceObjs, 0)||(-rSp / 5, rSp)
                _asteroids[i] = new Asteroid(new Point(Width, rnd.Next(1, Game.Heigth)), new Point(rSp / 2, 0), new Size(rSp * 5, rSp * 5));
            }

            for (int i = 0; i < _healings.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point( -i*r, -i*r )
                _healings[i] = new Healing(new Point(Width, rnd.Next(1, Game.Heigth)), new Point((rSp / 3) * 2, 0), new Size(1, 1));
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

        private static void InitializeSound()
        {
            // Create an instance of the SoundPlayer class.
            //player = new SoundPlayer();
            Sound.BackgroundMusic.PlaySync();
        }

        public static Ship _ship = new Ship(new Point(126, 126), new Point(12, 12), new Size(_shipWidth, _shipHeigth));

        private static void Form_KeyDown(object sender, KeyEventArgs e) // медод с логикой управления
        {
            //if (e.KeyCode == Keys.ControlKey) _ship.ShootBullet();
            if (e.KeyCode == Keys.ControlKey) _ship.ShootBullet();// = new Bullet(new Point(_ship.Rect.X + _shipWidth, _ship.Rect.Y + _shipHeigth / 2 - _bulletHeigth / 2), new Point(_bulletSpeed, 0), new Size(_bulletWidth, _bulletHeigth));
            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();
            //if (e.KeyCode == Keys.Escape) _ship.Die(); // TODO
            //if (e.KeyCode == Keys.Escape) Game.Finish();
            // CloseAllForms();
            //GamePause(e);
        }

        public static void Update()
        {
            _backGrnds[0]?.Update();
            _backGrnds[1]?.Update();

            if (_ship.Energy <= 0)
            {
                Finish();
            }

            //foreach (Comet comet in _comets)
            //{
            //}

            for (int i = 0; i < _comets.Length; i++)
            {
                //if (_comets[i].Collision(_ship?.Bullet))
                //{
                //CometsRepoint(rnd, rSp, i);
                //_comets[i] = new Point(Width, rnd.Next(1, Game.Heigth)), new Point((rSp / 3) * 2, 0), new Size(1, 1); 
                //System.
                // System.Media.SoundPlayer = ResourceTextures.Windows_Hardware_Remove;  //Hand.Play();
                //System.Media.SystemSounds.Hand.Play();
                //Console.Beep(600, 120);
                //_ship.BulletDestroy();
                //}
                _comets[i]?.Update();
            }
            //comet?.Update();

            foreach (Star star in _stars)
            {
                star?.Update();
                //if (star.Collision(_ship.Bullet))
                //{
                //    //System.Media.SystemSounds.Hand.Play();
                //    Console.Beep(400, 30);
                //}
            }

            foreach (Asteroid aster in _asteroids)
            {
                aster?.Update();
                //if (aster.Collision(_ship.Bullet))
                //{
                //    //System.Media.SystemSounds.Hand.Play();
                //    Console.Beep(200, 50);
                //}
            }

            foreach (Healing h in _healings)
            {
                h?.Update();
            }

            _ship?.Bullet?.Update();

            //ActionWithAsteroids();
            ActionWithComets();
            //ActionWithStar();
            ActionWithHealing();
        }




        public static void CometsRepoint(Random rnd, int rSp, int i)
            => _comets[i] = new Comet(new Point(Width, rnd.Next(1, Game.Heigth)),
                new Point((rSp / 3) * 2, 0), new Size(1, 1));


        private static void ActionWithAsteroids()
        {
            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null)
                    continue;

                if (_ship?.Bullet != null && _ship.Bullet.Collision(_asteroids[i]))
                {
                    //SystemSound.Hand.Play();
                    _asteroids[i] = null;
                    _ship?.BulletDestroy();
                    continue;
                }
                if (!_ship.Collision(_asteroids[i]))
                    continue;

                _ship?.EnergyLow(_asteroids[i].Damage);
                _asteroids[i] = null;

                // SystemSound.Asterisk.Play();
                if (_ship.Energy <= 0)
                    _ship?.Die();
            }
        }

        private static void ActionWithComets()
        {
            for (var i = 0; i < _comets.Length; i++)
            {
                if (_comets[i] == null) continue;
                _comets[i].Update();
                if (_ship.Bullet != null && _ship.Bullet.Collision(_comets[i]))
                {
                    Random rnd = new Random();
                    int rSp = rnd.Next(5, 50);
                    System.Media.SystemSounds.Hand.Play();
                    //_comets[i] = null;
                    CometsRepoint(rnd, rSp, i);
                    //_ship.Bullet = null;
                    continue;
                }

                if (_ship.Collision(_comets[i]))
                {
                    Random rnd = new Random();
                    int rSp = rnd.Next(5, 50);
                    //System.Media.SystemSounds.Asterisk.Play();
                    _ship?.EnergyLow(_comets[i].Damage);
                    CometsRepoint(rnd, rSp, i);

                    //_s1.Play();
                }
                //    if (!_ship.Collision(_comets[i])) continue;
                //    _comets[i] = null;
                //    System.Media.SystemSounds.Asterisk.Play();
            }

            for (int i = 0; i < _comets.Length; i++)
            {
                if (_comets[i] == null)
                    continue;

                if (_ship?.Bullet != null && _ship.Bullet.Collision(_comets[i]))
                {
                    //SystemSound.Hand.Play();
                    _comets[i] = null;
                    _ship?.BulletDestroy();
                    continue;
                }

                if (!_ship.Collision(_comets[i]))
                    continue;

                _ship?.EnergyLow(_comets[i].Damage);
                _comets[i] = null;

                // SystemSound.Asterisk.Play();
                if (_ship.Energy <= 0)
                    _ship?.Die();
            }
        }

        private static void ActionWithStar()
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                if (_stars[i] == null)
                    continue;

                if (_ship?.Bullet != null && _ship.Bullet.Collision(_stars[i]))
                {
                    //SystemSound.Hand.Play();
                    _stars[i] = null;
                    _ship?.BulletDestroy(); continue;
                }

                if (!_ship.Collision(_stars[i])) continue;

                _ship?.EnergyLow(_stars[i].Damage);
                _stars[i] = null;

                // SystemSound.Asterisk.Play();
                if (_ship.Energy <= 0)
                    _ship?.Die();
            }
        }

        private static void ActionWithHealing()
        {
            for (int i = 0; i < _healings.Length; i++)
            {
                if (_healings[i] == null)
                    continue;

                if (!_ship.Collision(_healings[i]))
                    continue;

                _ship?.EnergyHi(_healings[i].Heal);
                _healings[i] = null;
                Sound.SFXHeal.Play();
               //player.Play ( UriString);
               

                // SystemSound.Asterisk.Play();
            }
        }

        internal static void Draw()
        {
            //int w = 200;
            //int h = 200;
            Buffer.Graphics.Clear(Color.Empty);
            _backGrnds[0]?.Draw();
            _backGrnds[1]?.Draw();

            if (_ship != null)
            {
                _ship?.Draw();
                Buffer.Graphics.DrawString("Energy:" + _ship.Energy, new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold), Brushes.GreenYellow, 10, 5);

            }

            foreach (Comet comet in _comets) comet?.Draw();
            foreach (Star star in _stars) star?.Draw();
            foreach (Asteroid aster in _asteroids) aster?.Draw();
            foreach (Healing h in _healings) h?.Draw();
            //for (int i = _stars.Length - 1; i > 0; i--)
            //{
            //    _stars[i]?.Draw();
            //    //_stars[i]?.Draw();
            //}
            _ship?.Bullet?.Draw();
            Buffer.Render();
            //throw new NotImplementedException();
        }

        public static void Finish()
        {
            string _s = "The End";
            int _fontSize = 80;

            _timer.Stop();
            Buffer.Graphics.DrawString(_s, new Font(FontFamily.GenericSansSerif,
            _fontSize, FontStyle.Underline), Brushes.Orange, Game.Width / 2 - _fontSize * _s.Length / 3, Game.Heigth / 2 - _fontSize);
            Buffer.Render();

            //CloseAllForms();
        }

        private static void CloseAllForms()
        {//Thread // нельзя!!! Т.К. ломается таймер тик
            Form.ActiveForm.Close();
            Form1.ActiveForm.Close();
        }
    }
}
