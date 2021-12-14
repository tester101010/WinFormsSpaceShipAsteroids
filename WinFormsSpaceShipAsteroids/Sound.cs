using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Windows.Media;


namespace WinFormsSpaceShipAsteroids
{
    static class Sound
    {
        public static MediaPlayer music = new MediaPlayer();// ???
        public static System.Media.SoundPlayer BackgroundMusic = new System.Media.SoundPlayer("drama.wav");

        public static System.Media.SoundPlayer shotSound = new System.Media.SoundPlayer("laser.wav");
        public static System.Media.SoundPlayer SFXHeal = new SoundPlayer("dsitemup.wav");
        public static System.Media.SoundPlayer SFXExplosion1 = new SoundPlayer("dsbarexp.wav");
        public static System.Media.SoundPlayer SFXExplosion2 = new SoundPlayer("explos.wav");
        public static System.Media.SoundPlayer SFXHit = new SoundPlayer("Jump.wav");

    }

}
