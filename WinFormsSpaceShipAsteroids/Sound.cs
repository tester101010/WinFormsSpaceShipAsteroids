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
        public static System.Media.SoundPlayer shotSound = new System.Media.SoundPlayer("laser.wav");
        public static System.Media.SoundPlayer BackgroundMusic = new System.Media.SoundPlayer("drama.wav");
        public static System.Media.SoundPlayer SFXHeal = new SoundPlayer("dsitemup.wav");
        public static System.Media.SoundPlayer SFXExplosion1 = new SoundPlayer("dsbarexp.wav");
        public static System.Media.SoundPlayer SFXExplosion2 = new SoundPlayer("explos.wav");
        public static System.Media.SoundPlayer SFXHit = new SoundPlayer("Jump.wav");
        public static MediaPlayer music = new MediaPlayer();

    }
    //    public static System.Media.SoundPlayer screamSound = new System.Media.SoundPlayer("scream.wav");
    //    public static System.Media.SoundPlayer shotSound = new System.Media.SoundPlayer("shot.wav");
    //    public static System.Media.SoundPlayer shipDamageSound = new System.Media.SoundPlayer("dmg.wav");
    //    public static System.Media.SoundPlayer endSound = new System.Media.SoundPlayer("end.wav");
    //    public static System.Media.SoundPlayer metaHit = new System.Media.SoundPlayer("metalhit.wav");
    //    public static System.Media.SoundPlayer heal = new System.Media.SoundPlayer("heal.wav");
    //    public static MediaPlayer music = new MediaPlayer();
}
