namespace cgarza5Minesweeper
{
    /// <summary>
    /// Game interface class to set up the interface
    /// </summary>
    public partial class GameInterface : Form
    {

        /// <summary>
        /// Game interface constructor to set up the interface by initializing and running the game
        /// </summary>
        public GameInterface()
        {
            InitializeComponent();
            RunGame();
        }

        /// <summary>
        /// Run game method that gives controls to the other class and creates game
        /// </summary>
        public void RunGame()
        {
            Game game = new Game(Controls);
        }

        /// <summary>
        /// Statistics click handler that gives statistics upon click
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args </param>
        private void StatisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StreamReader reader = new StreamReader("Stats.txt");

            MessageBox.Show($"Wins: {reader.ReadLine()}\nLosses: {reader.ReadLine()}\nTime Average: {reader.ReadLine()}");

            reader.Close();
        }

        /// <summary>
        /// Restart game handler that restarts game upon click
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args </param>
        private void RestartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }


        /// <summary>
        /// Exit handler that exits game upon click
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args </param>
        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// Instructions handler that gives message box that shows the instructions of the game upon click
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args </param>
        private void InstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This is a game of Minesweeper! \n" +
                "(Not The Actual Minesweeper for Legal Reasons :D)\n" +
                "Instructions:\nThere are ten mines located throughout the board.\n" +
                "Each time you click a button two things will happen.\n" +
                "If there is no mine it will clear adjacent cells until a mine is reached!\n" +
                "If there is a mine you will explode which will increase your hit counter!\n" +
                "The game ends once you have hit two mines or completely cleared every button without a mine!\n" +
                "You can use the help section to get these instructions again or who made the game!\n" +
                "Lastly, the game section will show you overall statistics and enables you to restart or exit!\n" +
                "GOOD LUCK!");
        }

        /// <summary>
        /// About handler that gives information about creator and class upon click
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs </param>
        private void AboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By: Chris Garza \nClass: CS3020");
        }
    }
}
