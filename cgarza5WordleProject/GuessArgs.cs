using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleProject2
{
    /// <summary>
    /// Guess Args class in order to create args for guess event including an int and word
    /// </summary>
    public class GuessArgs
    {
        int rows;
        Word word;

        public int Rows { get => rows; set => rows = value; }
        public Word Word { get => word; set => word = value; }

    }
}
