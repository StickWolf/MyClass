using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundUtils
{


    public static class ABunchaSounds
    {
        public enum Song
        {
            MovesLikeJagger,
            UppyDowny
        }

        private static Dictionary<Song, string> songsCollection = new Dictionary<Song, string>()
        {
            [Song.MovesLikeJagger] = "e3r2t2y1y1t2r2e3w3e3r2t2y2y1y2",
            [Song.UppyDowny] = "e6e2w2e2r2t2y6u2y6y2y2t2r2e6r2e6e2r2t6r6t2r2e2",
        };

        public static void CreatureVictoryBeeps()
        {
            Console.Beep(500, 300);
            Console.Beep(600, 300);
            Console.Beep(700, 200);
            Console.Beep(800, 100);
            Console.Beep(800, 100);
            Console.Beep(700, 200);
            Console.Beep(600, 300);
            Console.Beep(500, 300);
            Console.Beep(400, 400);
            Console.Beep(500, 300);
            Console.Beep(600, 300);
            Console.Beep(700, 200);
            Console.Beep(800, 100);
            Console.Beep(700, 200);
            Console.Beep(600, 300);
        }

        public static void CreatureAttackBeeps()
        {
            Console.Beep(700, 500);
            Console.Beep(700, 500);
            Console.Beep(700, 500);
            Console.Beep(500, 500);
            Console.Beep(500, 500);
            Console.Beep(100, 1000);
        }

        public static void CreatureIntroBeeps()
        {
            Console.Beep(600, 500);
            Console.Beep(900, 500);
            Console.Beep(2200, 500);
            Console.Beep(800, 1000);
            Console.Beep(900, 1000);
        }

        public static void Piano()
        {
            var rnd = new Random();

            while (true)
            {
                var freq = rnd.Next(500, 600);
                var dur = rnd.Next(600, 700);
                //var bob = rnd.Next(700, 800);
                //var sno = rnd.Next(800, 900);
                var supa = rnd.Next(800, 900);
                Console.Beep(700, 100);
            }
        }

        public static void PlaySong(Song songToPlay)
        {
            string songChars = songsCollection[songToPlay];

            for (int i = 0; i < songChars.Length -2; i+=2)
            {
                try
                {
                    var key = songChars[i];
                    int duration = int.Parse(songChars[i + 1].ToString());
                    PlayByKey(key, duration);
                }
                catch (Exception ex)
                {
                    return;
                }
            }
        }

        public static void PlayByKey(char key, int duration)
        {
            var actualDuration = duration * 100;

            switch (key)
            {
                case 'q':
                    Console.Beep(300, actualDuration);
                    break;
                case 'w':
                    Console.Beep(400, actualDuration);
                    break;
                case 'e':
                    Console.Beep(500, actualDuration);
                    break;
                case 'r':
                    Console.Beep(600, actualDuration);
                    break;
                case 't':
                    Console.Beep(700, actualDuration);
                    break;
                case 'y':
                    Console.Beep(800, actualDuration);
                    break;
                case 'u':
                    Console.Beep(900, actualDuration);
                    break;
                case 'i':
                    Console.Beep(1000, actualDuration);
                    break;

                // The second row of keys are pre-recorded songs
                case 'a':
                    PlaySong(Song.MovesLikeJagger);
                    break;
                case 's':
                    PlaySong(Song.UppyDowny);
                    break;
            }
        }
    }
}
