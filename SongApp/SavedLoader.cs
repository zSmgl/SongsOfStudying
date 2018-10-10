using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SongApp
{
    class SavedLoader
    {
        // Data
        private string filename;
        private StreamReader input;
        private string song1;
        private string song2;

        Dictionary<string, string> savedPieces;

        //Properties

        Dictionary<string, string> SavedPieces
        {
            get { return savedPieces; }
        }


        /*  Saved File Format
         *  
         *  Song Used           [Saved as Key]
         *  ---                 [readIn -> T]
         *  Lyrics to Song      [Added to Lyrics]
         *  ---                 [adds to Dict && readsIn -> F && resets for next]
         *  /Repeated..../
         * 
         */

        public SavedLoader(string song1, string song2)
        {
            filename = "saved.txt";
            input = null;
            this.song1 = song1;
            this.song2 = song2;
            savedPieces = new Dictionary<string, string>();

            ReadSavedFiles();
        
        }

        private void ReadSavedFiles()
        {
            try
            {
                input = new StreamReader(filename);
                string line = "";
                string key = null;
                string value = null;
                string lyrics = "";
                bool readIn = false;

                while ((line = input.ReadLine()) != null)
                {
                    if(line.Contains(song1) || line.Contains(song2))
                    {
                        key = line;
                    }
                    else if(line != "---")
                    {
                        value = line;
                        lyrics += value;
                    }
                    else if(line == "---")
                    {
                        if(readIn == true)
                        {
                            savedPieces.Add(key, value);
                            key = null;
                            value = null;
                            lyrics = "";
                        }
                        readIn = !readIn;
                    }
                }

                if (input != null)
                {
                    input.Close();
                }

                // Testing Confirmation of Reading into Lines
                Console.WriteLine("SavedPieces Loaded Successfully!");
            }
            // Output if reading in wrong
            catch (Exception e)
            {
                Console.WriteLine("Error Reading file: " + e.Message);
            }
        }
    }
}
