using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SongApp
{

    class InputFormatter
    {
        // Text Input information
        private StreamReader input;
        private string notesFile;
        private string wordsFile;

        // Lists
        private List<string> nonEssentialWords;
        private List<string> removedVersion;

        // To make song from
        private List<string> phrases;
        private List<string> importantWords;

        //Properties - Access to main Program Choosing Phrases and Words for Associated Song
        public List<string> Phrases
        {
            get { return phrases; }
        }

        public List<string> IW
        {
            get { return importantWords; }
        }

        // Constructor
        public InputFormatter(string filename)
        {
            // Set Up
            notesFile = filename;
            wordsFile = "words.txt";
            input = null;


            nonEssentialWords = new List<string>();     // List of Words that should be checked within imported notes.
            removedVersion = new List<string>();        // Remaining list of words that survived the first check

            /*
             * Add In a function that adds in important phrases that should be kept together into a list
             * Add in a function that adds important individual key words to a list
             */

            // Steps in formatting the document
            AddNon();   // Adds in list of unneeded words
            Load();     // Loads in the notes | Removes words deemed unneeded.
            Sort();     // Divides the Remaining words into 3 New Lists: Each one with their own priority level of needing to make the song.
            

        }

        /// <summary>
        /// Reads in all words deemed unneccessary from a text file to be removed from a person's notes;
        /// </summary>
        private void AddNon()
        {
            try
            {
                input = new StreamReader(wordsFile);
                string line = "";

                while ((line = input.ReadLine()) != null)
                {
                    nonEssentialWords.Add(line);
                }

                if (input != null)
                {
                    input.Close();
                }

                // Testing Confirmation of Reading into Lines
                Console.WriteLine("WordFile Loaded Successfully!");
            }
            // Output if reading in wrong
            catch (Exception e)
            {
                Console.WriteLine("Error Reading file: " + e.Message);
            }
        }

        /// <summary>
        /// Loads in the notes correctly
        /// </summary>
        private void Load()
        {
            try
            {
                input = new StreamReader(notesFile);
                string line = "";

                while ((line = input.ReadLine()) != null)
                {
                    // Adds a version of the line with the removed words to a List of Strings to be further formated later. 
                    removedVersion.Add(FormatText(line));
                }

                if (input != null)
                {
                    input.Close();
                }

                // Testing Confirmation of Reading into Lines
                Console.WriteLine("Notes Loaded Successfully!");
            }
            // Output if reading in wrong
            catch (Exception e)
            {
                Console.WriteLine("Error Reading file: " + e.Message);
            }
        }

        /// <summary>
        /// Formats the given line of text from nthe notes and removes any unneeded words
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        private string FormatText(string line)
        {
            // Loops through all unneeded words. 
            foreach(string word in nonEssentialWords)
            {
                // If an unneeded word is spoted in this particular line of notes
                // It is replaced with nothing. 
                if(line.Contains(word) == true)
                {
                    // Replaces the word with nothing if it is in the middle of the given line
                    line = line.Replace(" " + word + " ", " ");
                    // Replaces the word if it is at the end of the sentence.
                    line = line.Replace(word + ".", " ");
                }
            }

            return line;
        }

        private void Sort()
        {

        }
    }
}
