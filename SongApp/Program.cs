using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongApp
{
    class Program
    {
        static void Main(string[] args)
        {

            // Setup
            string filename = "notes.txt";
            string song1 = "Song1.wav";
            string song2 = "Song2.wav";
            InputFormatter formatter = new InputFormatter(filename);

            // Loads in .wav files to be played.
            System.Media.SoundPlayer song1Player = new System.Media.SoundPlayer(song1);
            System.Media.SoundPlayer song2Player = new System.Media.SoundPlayer(song2);

            SavedLoader savedCombos = new SavedLoader(song1, song2);


            AppUI application = new AppUI();



            application.Load();
            application.Run();
        }
    }
}
