using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleProject2
{

    /// <summary>
    /// Word randomizer to create random word based on file read
    /// </summary>
    public class WordRandomizer
    {
        string word;
        int lines = File.ReadLines("wordle-answers-alphabetical.txt").Count();
        Random randomGen = new Random();

        /// <summary>
        /// RandomWord class in order to create random int with random and then get word from file with the random int
        /// </summary>
        /// <returns> Returns word randomly selected from file </returns>
        public string RandomWord()
        {
            int randomLine = randomGen.Next(0, lines);
            word = File.ReadLines("wordle-answers-alphabetical.txt").Skip(randomLine).First();
            return word;
        }
    }
}
