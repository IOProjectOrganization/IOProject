using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra
{
    public static class Sound
    {
        public static WMPLib.WindowsMediaPlayer SoundPlayer = new WMPLib.WindowsMediaPlayer();  //odtwaracz dzwiekow(tylko raz)
        public static WMPLib.WindowsMediaPlayer SongPlayer = new WMPLib.WindowsMediaPlayer();  //odtwarzacz muzyki(powtarza sie po zakonczeniu)

        // Sounds - efekty dzwiekowe
        public const string Sound_playerbasicattack = @"Sounds/playerbasicattack.wav";   // IOProject/Gra/Gra/bin/Debug/Sounds/playerbasicattack.wav

        public const string Sound_enemybasicattack = @"Sounds/enemybasicattack.wav";
        public const string Sound_enemyattackspell = @"Sounds/enemyattackspell.wav";
        public const string Sound_enemyhealingspell = @"Sounds/enemyhealingspell.wav";

        public const string Sound_itempickup = @"Sounds/itempickup.wav";
        //np. przy ataku Sound.PlaySound(Sound.Sound_playerbasicattack);


        // Songs - muzyka



        public static void PlaySound(string _sound)
        {
            SoundPlayer.URL = _sound;
            SoundPlayer.controls.play();
        }
        public static void StopSound()  // jesli chcemy na sile zatrzymac dzwiek
        {
            SoundPlayer.controls.stop();
        }

        public static void PlaySong(string _song)
        {
            if (SongPlayer.URL != _song)
            {
                SongPlayer.URL = _song;
                SongPlayer.settings.setMode("loop", true);  //zapetlanie muzyki
                SongPlayer.controls.play();
            }
        }
        public static void StopSong()  // jesli chcemy na sile zatrzymac muzyke
        {
            SongPlayer.controls.stop();
        }
    }
}
