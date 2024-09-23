using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleProject2
{

    /// <summary>
    /// Word class to create word with char array and also includes just the string
    /// </summary>
    public class Word
    {
        char[] letterArray = new char[5];
        string word;

        /// <summary>
        /// Word constructor that takes string to set the word string then array
        /// </summary>
        /// <param name="word"> word parameter to set word string to word given</param>
        public Word(string word)
        {
            this.word = word;
            letterArray = word.ToCharArray();
        }

        /// <summary>
        /// Returns length of word
        /// </summary>
        /// <returns></returns>
        public int getLength()
        {
            return letterArray.Length;
        }

        /// <summary>
        /// Returns array associated with word
        /// </summary>
        /// <returns></returns>
        public char[] getArray()
        {
            return letterArray;
        }

        /// <summary>
        /// Returns word string
        /// </summary>
        /// <returns></returns>
        public string getWord()
        {
            return word;
        }
    }
}
