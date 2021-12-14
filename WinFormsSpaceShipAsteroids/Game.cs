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
// 1) пофиксить медиа файлы и папки                V
// 2) сделать метод паузы и выход из приложения    +-
// 3) сделать звуки и музыку в игре                V
// 4) сделать анимацию взрывов и огонь двигателя коробля 
//  ) 
// LAST) сделать меню паузы и настроек (GUI)

namespace WinFormsSpaceShipAsteroids
{

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

        private static bool _Pause = false;

        //private static Bullet _bullet; // ToDo
        //private static int _bulletSpeed = 33;
        //private static int _bulletHeigth = 33;
        //private static int _bulletWidth = 14;
        //private static SoundPlayer _s1 = "cow.wav";
        //private static SoundPlayer player;
        //private const string UriString = "drama.wav";

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

            _comets = new Comet[3];
            _stars = new Star[20];
            _asteroids = new Asteroid[4];
            _healings = new Healing[4];

            //Sound.music.Open(new Uri(UriString, UriKind.Relative)); // загрузка фоновой музыки
            InitializeGameMusic();

            #region V1
            for (int i = 0; i < _comets.Length; i++)
            {
                int rSp = rnd.Next(5, 50);                                        // new Point( -i*r, -i*r )
                _comets[i] = new Comet(new Point(Width, rnd.Next(1, Game.Heigth)), new Point((rSp / 3) * 2, 0), new Size(1, 1));
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

        private static void InitializeGameMusic()
        {
            Sound.BackgroundMusic.Play();
            //Sound.BackgroundMusic.PlaySync();
        }

        public static Ship _ship = new Ship(new Point(126, 126), new Point(12, 12), new Size(_shipWidth, _shipHeigth));

        private static void Form_KeyDown(object sender, KeyEventArgs e) // медод с логикой управления
        {

            if (e.KeyCode == Keys.Up) _ship.Up();
            if (e.KeyCode == Keys.Down) _ship.Down();
            if (e.KeyCode == Keys.Left) _ship.Left();
            if (e.KeyCode == Keys.Right) _ship.Right();

            if (e.KeyCode == Keys.ControlKey) _ship.ShootBullet();
            if (e.KeyCode == Keys.Escape) GamePause();
            // CloseAllForms();
        }

        private static void GamePause()
        {
            if (_Pause == false)
            {
                _Pause = true;
                _timer.Stop();

                string _s = "PAUSE";
                int _fontSize = 80;

                Buffer.Graphics.DrawString(_s, new Font(FontFamily.GenericSansSerif, _fontSize, FontStyle.Regular),
                    Brushes.Orange, Game.Width / 2 - _fontSize * _s.Length / 3, Game.Heigth / 2 - _fontSize);
                Buffer.Render();
            }
            else
            {
                _Pause = false;
                _timer.Start();
            }
            //throw new NotImplementedException();
        }

        public static void Update()
        {
            _backGrnds[0]?.Update();
            _backGrnds[1]?.Update();

            if (_ship.Energy <= 0)
            {
                Finish();
            }
            //if (_ship != null && _ship.Energy <= 0)
            //{
            //    Finish();
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

            ActionWithAsteroids();
            ActionWithComets();
            //ActionWithStar(); // for 3D visual effect
            ActionWithHealing();
        }




        public static void CometsRepoint(Random rnd, int rSp, int i)
            => _comets[i] = new Comet(new Point(Width, rnd.Next(1, Game.Heigth)),
                new Point((rSp / 3) * 2, 0), new Size(1, 1));


        private static void ActionWithAsteroids()
        {
            int addScores = 10;
            for (int i = 0; i < _asteroids.Length; i++)
            {
                if (_asteroids[i] == null) continue;
                //_asteroids[i].Update();

                if (_ship?.Bullet != null && _ship.Bullet.Collision(_asteroids[i]))
                {
                    Sound.SFXExplosion1.Play();

                    _asteroids[i] = null;
                    _ship.ScoreIncrease(addScores);
                    _ship?.BulletDestroy();
                    continue;
                }

                if (_ship.Collision(_asteroids[i]))
                {
                    Sound.SFXHit.Play();

                    _ship?.EnergyLow(_asteroids[i].Damage);
                    _asteroids[i] = null;
                }
            }
        }

        private static void ActionWithComets()
        {
            int addScores = 500;
            for (var i = 0; i < _comets.Length; i++)
            {
                if (_comets[i] == null) continue;
                _comets[i].Update();

                if (_ship.Bullet != null && _ship.Bullet.Collision(_comets[i]))
                {
                    Sound.SFXExplosion1.Play();

                    Random rnd = new Random();
                    int rSp = rnd.Next(5, 50);

                    _comets[i] = null;
                    _ship.ScoreIncrease(addScores);
                    _ship?.BulletDestroy();
                    CometsRepoint(rnd, rSp, i);
                    continue;
                }

                if (_ship.Collision(_comets[i]))
                {
                    Random rnd = new Random();
                    int rSp = rnd.Next(5, 50);

                    _ship?.EnergyLow(_comets[i].Damage);
                    CometsRepoint(rnd, rSp, i);
                    Sound.SFXHit.Play();

                }
            }
        }

        private static void ActionWithStar()
        {
            for (int i = 0; i < _stars.Length; i++)
            {
                if (_stars[i] == null)
                    continue;

                if (_ship.Collision(_stars[i]))
                {
                    Sound.SFXHit.Play();
                    _ship?.EnergyLow(_stars[i].Damage);
                    _stars[i] = null;
                }
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

            if (_ship.Energy > 0)
            {
                if (_ship != null)
                {
                    _ship?.Draw();
                    Buffer.Graphics.DrawString("Energy:" + _ship.Energy, new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold), Brushes.GreenYellow, 10, 5);
                    Buffer.Graphics.DrawString("Scores:" + _ship.Scores, new Font(FontFamily.GenericSansSerif, 15, FontStyle.Bold), Brushes.GreenYellow, Game.Width - 150, 5);
                }
                _ship?.Bullet?.Draw();

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

            Buffer.Render();
        }

        public static void Finish()
        {
            Sound.SFXExplosion2.PlaySync();


            string _s1 = "The End";
            int _fontSize_S1 = 80;

            Buffer.Graphics.DrawString(_s1, new Font(FontFamily.GenericSansSerif, _fontSize_S1, FontStyle.Underline),
                Brushes.Orange, Game.Width / 2 - _fontSize_S1 * _s1.Length / 3 - _fontSize_S1 / 2, Game.Heigth / 2 - _fontSize_S1);

            string _s2 = $"Your scores {_ship.Scores}";
            int _fontSize_S2 = 40;

            Buffer.Graphics.DrawString(_s2, new Font(FontFamily.GenericSansSerif, _fontSize_S2, FontStyle.Underline),
                Brushes.LemonChiffon, Game.Width / 2 - _fontSize_S2 * _s2.Length / 3, Game.Heigth / 4 - _fontSize_S2);

            Buffer.Render();
            _timer.Stop();
            //_ship = null;
            //CloseAllForms();
        }

        private static void CloseAllForms()
        {//Thread // нельзя!!! Т.К. ломается таймер тик
            Form.ActiveForm.Close();
            Form1.ActiveForm.Close();
        }
    }
}
