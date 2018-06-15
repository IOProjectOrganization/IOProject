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
        public const string Sound_goldpickup = @"Sounds/goldpickup.wav";
        public const string Sound_healing = @"Sounds/healing.wav";
        public const string Sound_weararmor = @"Sounds/weararmor.wav";
        public const string Sound_wearweapon = @"Sounds/wearweap.wav";

        public const string Sound_questupdate = @"Sounds/questupdate.wav";

        //np. przy ataku Sound.PlaySound(Sound.Sound_playerbasicattack);


        // Songs - muzyka
        public const string Song_menu = @"Sounds/menu.wav";
        public const string Song_battle = @"Sounds/epicbattle.wav";
        public const string Song_cave = @"Sounds/cave.wav";
        public const string Song_grassland = @"Sounds/grasslands.wav";
        //public const string Song_menu = @"Sounds/city.wav";

        public const string Song_marketplace = @"Sounds/marketplace.wav";

        public const string Song_victory = @"Sounds/gameover_victory.wav";
        public const string Song_lost = @"Sounds/gameover_lost.wav";


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
        public static void SongPause()
        {
            SongPlayer.controls.pause();
        }
        public static void SongUnpause()
        {
            SongPlayer.controls.play();
        }
    }
}
