using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WordleProject2
{

    /// <summary>
    /// Game Functions class that includes various functions to be used by the game
    /// </summary>
    public class GameFunctions : EventArgs
    {
        WordRandomizer randomizer = new WordRandomizer();
        Word word;
        StreamReader reader;
        public event EventHandler<GuessArgs>? Guess;

        /// <summary>
        /// GameFunctions constructor that simply creates a new word everytime game functions is called
        /// </summary>
        public GameFunctions()
        {
            word = new Word(randomizer.RandomWord());

        }

        /// <summary>
        /// NewGuess function that creates guessargs then sends them to event
        /// </summary>
        /// <param name="rows"> Rows integer argument to know which guess the user is on</param>
        public void NewGuess(int rows)
        {
            GuessArgs args = new GuessArgs();
            args.Rows = rows;
            args.Word = word;
            OnNewGuess(this, args);
        }

        /// <summary>
        /// Event function that invokes guess event to be handled
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> GuessArgs </param>
        protected virtual void OnNewGuess(object sender, GuessArgs e)
        {
            Guess?.Invoke(sender, e);
        }


        /// <summary>
        /// CheckRealWord function iterates through word file and checks to see if the word matches any of the existing words
        /// </summary>
        /// <param name="grid"> textbox grid that contains guess </param>
        /// <param name="row"> row integer that contains guess number </param>
        /// <returns></returns>
        public bool CheckRealWord(TextBox[,] grid, int row)
        {

            //Variables created for logic
            reader = new StreamReader("wordle-answers-alphabetical.txt");
            bool realWord = false;
            String testString;
            String answerString = null;
            int wordMatch = 0;

            //For loop to create answer string to compare reader strings to
            for (int i = 0; i < grid.GetLength(1); i++)
            {
                answerString += grid[row, i].Text[0].ToString();
            }

            //While loop that takes testString then compares it to answer string
            while((testString = reader.ReadLine()) != null)
            {
                if(testString == answerString)
                {
                    wordMatch++;
                }
            }

            //If the word matches sets realword to true
            if (wordMatch == 1)
            {
                realWord = true;
            }

            return realWord;
        }

        /// <summary>
        /// CheckMatches function takes in grid and guess number to compare the guess to the actual word.
        /// </summary>
        /// <param name="grid"> textbox grid containg answer </param>
        /// <param name="row"> row integer to know which guess it is </param>
        public void CheckMatches(TextBox[,] grid, int row)
        {
            //Creation of arrays to help with checking guess
            char[] wordArray = word.getArray();
            int[] countArray = { 1, 1, 1, 1, 1 };

            //For loop that checks 1 on 1 letters to find any perfect matches then sets countArray to 0 if there is a match
            for (int place = 0; place < grid.GetLength(1); place++)
            {
                if (grid[row, place].Text[0] == (char)wordArray[place])
                {
                    SetGreen(grid[row, place]);
                    countArray[place]--;
                }
            }

            //For loop to iterate the guess based on each letter of the actual answer. If answer is found makes sure that the letter was not already flagged.
            //If not will set the countArray to 0 to flag.
            for (int wordPlace = 0; wordPlace < wordArray.Length; wordPlace++)
            {
                for (int textboxPlace = 0; textboxPlace < grid.GetLength(1); textboxPlace++)
                {
                    if (grid[row, textboxPlace].Text[0] == (char)wordArray[wordPlace] && countArray[wordPlace] != 0)
                    {
                        SetYellow(grid[row, textboxPlace]);
                        countArray[wordPlace]--;
                    }

                }
            }

            //for loop to iterate through grid and set any remaining box to red since no previous match was found
            for(int notMatched = 0; notMatched < countArray.Length; notMatched++)
            {
                if (grid[row,notMatched].BackColor != Color.Green && grid[row,notMatched].BackColor != Color.Yellow)
                {
                    SetRed(grid[row, notMatched]);

                }
            }

        }


        //SetYellow function to set given textbox to yellow
        public void SetYellow(TextBox textBox)
        {
            textBox.BackColor = Color.Yellow;
        }

        //SetGreen function to set given textbox to green
        public void SetGreen(TextBox textBox)
        {
            textBox.BackColor = Color.Green;
        }

        //SetRed function to set given textbox to red
        public void SetRed(TextBox textBox)
        {
            textBox.BackColor = Color.Red;
        }

    }
}
