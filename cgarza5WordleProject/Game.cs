using System.CodeDom.Compiler;
using WordleProject2;

namespace WinFormsApp1
{
    /// <summary>
    /// Game class that runs the game
    /// </summary>
    public partial class Game : Form
    {
        //Variables used to run game
        TextBox[,] grid = new TextBox[6, 5];
        int verticalOffset = 90;
        int horizontalOffset = 90;
        int spacing = 5;
        int textBoxCount = 1;
        GameFunctions game = new GameFunctions();
        Word word;
        WordRandomizer randomizer = new WordRandomizer();
        int row = 0;
        bool endGame = true;
        
        /// <summary>
        /// Game constructor to initialize and set up grid
        /// </summary>
        public Game()
        {
            InitializeComponent();
            SetUpTextBoxGrid();
            
        }

        /// <summary>
        /// SetUpTextBoxGrid function that create text box grid with event handlers for keys pressed and color change
        /// </summary>
        public void SetUpTextBoxGrid()
        {
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    //Textbox variables
                    TextBox temp = new TextBox();
                    temp.Size = new Size(90, 90);
                    temp.MaxLength = 1;
                    temp.Font = new Font("Arial", 45);

                    //Textbox location and margine
                    temp.Location = new Point(horizontalOffset + col * (temp.Width + spacing), verticalOffset + row * (temp.Height + spacing));
                    temp.Margin = new Padding(90);

                    //Textbox handlers and initially set to disabled
                    temp.KeyPress += OnKeyPressed;
                    temp.Enabled = false;
                    temp.BackColorChanged += OnBackColorChanged;
                    grid[row, col] = temp;
                    this.Controls.Add(grid[row, col]);
                }
            }
        }

        /// <summary>
        /// OnKeyPressed Handler that takes key pressed arguments and checks for actual letter or backspace then sets handled based on allowed letter
        /// </summary>
        /// <param name="sender"> Sender object </param>
        /// <param name="e"> KeyPress args </param>
        public void OnKeyPressed(object sender, KeyPressEventArgs e)
        {   
            //if statement that checks for backspace or letter key pressed then sends to validkeyentered else handles the key
            if (e.KeyChar == (char)Keys.Back || char.IsLetter(e.KeyChar))
            {
                e.Handled = false;
                ValidKeyEntered(sender, e); 
            }
            else
            {
                e.Handled = true;
            }
        }


        /// <summary>
        /// ValidKeyEntered function that sends key based on character entered
        /// </summary>
        /// <param name="sender"> Sender object </param>
        /// <param name="e"> KeyPress args </param>
        public void ValidKeyEntered(object sender, KeyPressEventArgs e)
            {

            //Checks if keypressed is back then checks if the count is not 1 in order to send shift tab
            if (e.KeyChar == (char)Keys.Back)
            {
                if (textBoxCount != 1)
                {
                    SendKeys.Send("+{TAB}");
                    textBoxCount--;
                }
            }
            //Checks if keypressed is a letter then automatically sends tab unless textBoxCount is max
            else if (char.IsLetter(e.KeyChar))
            {
                if (textBoxCount != 5)
                {
                    SendKeys.Send("{TAB}");
                    textBoxCount++;
                }
            }
        }

        /// <summary>
        /// GuessButtonClick handler to handle button click
        /// </summary>
        /// <param name="sender"> Sender object </param>
        /// <param name="e"> event args</param>
        private void GuessButtonClick(object sender, EventArgs e)
        {

            //If the endgame bool is false checks if all the boxes have letters then checks for a real word
            //then checks the matching letter and increments guess row. Then sends the row amount to NewGuess function
            //functions raises event which is handled by CheckGuess. Then sets enabled textboxes based on guess.
            if (endGame == false)
            {
                if (textBoxCount == 5)
                {
                    if (game.CheckRealWord(grid, row) == true)
                    {
                        game.CheckMatches(grid, row);
                        textBoxCount = 1;
                        this.row++;
                        game.NewGuess(row);
                        game.Guess += CheckGuess;
                        SetEnabled();
                    }

                    //if not a real word prompts that valid word was not entered
                    else
                    {
                        MessageBox.Show("You must enter a valid word!");
                    }
                }

                //if not 5 letters prompts for a complete word
                else
                {
                    MessageBox.Show("You must enter a complete word!");
                }
            }
            //End game is automatically set to true so no matter if you are pressing newgame or guess at the beginning a new game is started
            else
            {
                StartNewGame();
            }
        }

        /// <summary>
        /// NewGameButtonClick handler to start new game when button is clicked
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs </param>
        private void NewGameButtonClick(object sender, EventArgs e)
        {
            StartNewGame();
        }

        /// <summary>
        /// StartNewGame function that prompts the user if they would like to start a new game then starts new game based on yes or no answer.
        /// </summary>
        private void StartNewGame()
        {
            DialogResult result = MessageBox.Show("Would you like to start a new game?", "", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                game = new GameFunctions();
                resetGrid();
            }
        }

        /// <summary>
        /// ResetGrid function that takes the grid, resets the letters, resets the color, resets enabled boxes, and sets letter count back to 1.
        /// </summary>
        public void resetGrid()
        {
            //for loop to reset grid and count
            for (int row = 0; row < grid.GetLength(0); row++)
            {
                for (int col = 0; col < grid.GetLength(1); col++)
                {
                    grid[row, col].Text = "";
                    grid[row, col].BackColor = Color.White;
                    grid[row, col].Enabled = false;
                    textBoxCount = 1;
                }
            }
            //Sets row to 0 and endgame to false to start a new game and allow guesses
            //also sets enabled to enable first guess textboxes
            this.row = 0;
            endGame = false;
            SetEnabled();
        }


        /// <summary>
        /// SetEnabled function takes guess row and enables that row
        /// </summary>
        public void SetEnabled()
        {
            //If the game has not ended takes number of textboxes in row and sets them to enabled then disables previous
            if (endGame == false)
            {
                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    grid[this.row, i].Enabled = true;
                    if (row != 0)
                    {
                        grid[this.row - 1, i].Enabled = false;
                    }
                }
            }
            //Else disables all of the boxes since the guesses would be at max
            else
            {
                for (int row = 0; row < grid.GetLength(0); row++)
                {
                    for (int col = 0; col < grid.GetLength(1); col++)
                    {
                        grid[row, col].Enabled = false;
                    }
                }
            }
        }

        /// <summary>
        /// HelpClick handler that whenever the help button is pressed displays directions to play.
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> Eventargs </param>
        private void HelpClick(object sender, EventArgs e)
        {
            MessageBox.Show("This is another Wordle Game!\nYou are trying to guess the word the computer chose!" +
                "\nYou must type in a 5 letter word then click guess!\n" +
                "If the guess is not 5 letters or a real word it will not work!\nYou have six guesses to get the word right!" +
                "\nPress new game to start a new game! Good Luck!", "Directions");
        }

        /// <summary>
        /// OnBackColorChanged handler to check if all the boxes are green and display win game
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs </param>
        private void OnBackColorChanged(object sender, EventArgs e)
        {
            //if endgame is false checks each textbox to see if it is green
            if (endGame == false)
            {
                bool greenCheck = true;

                for (int i = 0; i < grid.GetLength(1); i++)
                {
                    if (grid[row, i].BackColor != Color.Green)
                    {
                        greenCheck = false;
                    }
                }

                //If greencheck bool is still true displays won game message then endsgame and prompts for new game
                if (greenCheck == true)
                {
                    MessageBox.Show("You won the game!");
                    endGame = true;
                    StartNewGame();
                }
            }

        }

        /// <summary>
        /// CheckGuess handler that when the guess event is raised checks to see if max amount of guesses is used
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckGuess(object sender, GuessArgs e)
        {
            //If max amount of guesses is used and the endGame isn't true due to being the right answer tells the user the word and asks if they would
            //like to start a new game
            if (e.Rows == 6 && endGame != true)
            {
                e.Rows = 0;
                endGame = true;
                MessageBox.Show("The word was " + e.Word.getWord() + ". Better luck next time!");
                StartNewGame();
            }
        }
    }
}
