using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Game stats class for game high score and levels completed
    /// </summary>
    public class GameStats : EventArgs
    {
        int highScore = 0;
        int levelsCompleted = 0;

        public int HighScore { get=> highScore; set => highScore = value; }

        public int LevelsCompleted { get => levelsCompleted; set => levelsCompleted = value; }



    }
}
