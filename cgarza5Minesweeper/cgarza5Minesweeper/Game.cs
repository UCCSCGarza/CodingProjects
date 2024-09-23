using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices.Marshalling;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace cgarza5Minesweeper
{
    /// <summary>
    /// Game class that runs the game with various methods and handlers
    /// </summary>
    internal class Game : EventArgs
    {

        //Game Variables
        private bool firstButtonClick = true;
        private GameBoard board;
        private event EventHandler<GameBoard>? gameBoard;
        private int offset = 45;
        private int spacing = 5;
        private Random random = new Random();
        private int numberOfMines = 10;
        private System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
        private TextBox textbox;
        private TimeSpan time = TimeSpan.Zero;
        private int buttonTotal = 100;
        private int minesHit = 0;
        private bool win = false;


        /// <summary>
        /// Game Constructor that creates game board and runs logic
        /// </summary>
        /// <param name="Controls">Controls to tie panels and buttons into controls</param>
        public Game(Control.ControlCollection Controls)
        {
            board = new GameBoard();
            SetUpTextBox(Controls);
            BuildGameBoard(Controls);
            GameLogic();
        }

        /// <summary>
        /// Sets up text box used for timer
        /// </summary>
        /// <param name="Controls">Controls in order to add textbox to form</param>
        public void SetUpTextBox(Control.ControlCollection Controls)
        {
            TextBox temp = new TextBox();
            temp.Location = new Point(195, 549);
            temp.Font = new Font("Arial", 12);
            temp.Size = new Size(200, 20);
            temp.TextAlign = HorizontalAlignment.Center;
            temp.Text = "Timer:";
            temp.Enabled = false;
            textbox = temp;
            Controls.Add(textbox);
        }


        /// <summary>
        /// BuildGameBoard creates gameboard by creating individual panels and buttons to be used by the logic
        /// Then it sets each array to corresponding panel and button
        /// </summary>
        /// <param name="Controls"> Controls to add buttons and panels to form </param>
        public void BuildGameBoard(Control.ControlCollection Controls)
        {
            //For loop to iterate through boards
            for (int row = 0; row < board.ButtonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < board.ButtonBoard.GetLength(1); col++)
                {
                    //Parameters given to each button and panel
                    Button tempButton = new Button();
                    Panel tempPanel = new Panel();
                    tempButton.Size = new Size(45, 45);
                    tempPanel.Size = new Size(45, 45);

                    tempButton.Location = new Point(offset + col * (tempButton.Width + spacing), offset + row * (tempButton.Height + spacing));
                    tempPanel.Location = new Point(offset + col * (tempPanel.Width + spacing), offset + row * (tempPanel.Height + spacing));
                    tempButton.Margin = new Padding(90);
                    tempPanel.Margin = new Padding(90);

                    tempButton.BackColor = Color.Tan;
                    tempButton.MouseClick += OnButtonClicked;
                    tempPanel.BackColor = Color.Gray;

                    //Adds buttons and panels to controls
                    board.ButtonBoard[row, col] = tempButton;
                    board.PanelBoard[row, col] = tempPanel;
                    Controls.Add(board.ButtonBoard[row, col]);
                    Controls.Add(board.PanelBoard[row, col]);

                }
            }
        }

        /// <summary>
        /// Button click handler that takes various instances of when the button is being clicked and decides what to do
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> Eventargs </param>
        public void OnButtonClicked(object sender, EventArgs e)
        {
            //Creation of button that was clicked by getting it from sender
            Button buttonClicked = (Button)sender;

            //Collects button row and button col to use
            int row = board.GetButtonRow(buttonClicked);
            int col = board.GetButtonCol(buttonClicked);

            //If to check whether or not its the first click to start the timer
            if(firstButtonClick == true)
            {
                timer.Interval = 1000;
                timer.Tick += new EventHandler(OnTimerTick);
                timer.Start();
                firstButtonClick = false;
            }

            //Checks bool board to see if it has a mine or not
            if (board.BoolBoard[row,col] == false)
            {
                //Changes said button to be invisible then checks adjacent cells
                buttonClicked.Visible = false;
                ClearAdjacentButtons(row, col);

                //Checks too see if the game is over and stops timer
                CheckButtonTotal();
                if (buttonTotal == 10)
                {
                    MessageBox.Show("You Won The Game!");
                    win = true;
                    ClearAllButtons();
                    timer.Stop();
                }
                buttonTotal = 100;
            }
            //Else if it is mine still sends button to false but shows that they hit a mine by giving red mine png
            //Then checks if they hit the max mines and stops timer and displays message
            else
            {
                buttonClicked.Visible = false;
                board.PanelBoard[row, col].BackgroundImage = Image.FromFile("RedMine.png");
                minesHit++;
                if(minesHit == 2)
                {
                    timer.Stop();
                    MessageBox.Show("You Lose! Better Luck Next Time!");
                    ClearAllButtons();

                }
            }
        }

        /// <summary>
        /// Clear adjacent buttons method to clear adjacent buttons depending on mine or number
        /// </summary>
        /// <param name="row"> initial row used for algorithm </param>
        /// <param name="col"> initial col used for algorithm </param>
        public void ClearAdjacentButtons(int row, int col)
        {
            int topRow = row - 1;
            int bottomRow = row + 1;
            int leftCol = col - 1;
            int rightCol = col + 1;

            //If statements to go through various sides of each button and recursively do it with each button after
            //If that checks the row above the button
            if (topRow > 0)
            {
                if (board.BoolBoard[topRow, col] == false && board.ButtonBoard[topRow, col].Visible == true)
                {
                    board.ButtonBoard[topRow, col].Visible = false;
                    if (board.PanelBoard[topRow, col].BackColor == Color.White)
                    {
                        ClearAdjacentButtons(topRow, col);
                    }
                }
            }
            //If that checks the row below the button
            if (bottomRow < 10)
            {
                if (board.BoolBoard[bottomRow, col] == false && board.ButtonBoard[bottomRow, col].Visible == true)
                {
                    board.ButtonBoard[bottomRow, col].Visible = false;
                    if (board.PanelBoard[bottomRow, col].BackColor == Color.White)
                    {
                        ClearAdjacentButtons(bottomRow, col);
                    }
                }
            }
            //If that checks the left col left of the button
            if (leftCol > 0)
            {
                if (board.BoolBoard[row, leftCol] == false && board.ButtonBoard[row, leftCol].Visible == true)
                {
                    board.ButtonBoard[row, leftCol].Visible = false;
                    if (board.PanelBoard[row, leftCol].BackColor == Color.White)
                    {
                        ClearAdjacentButtons(row, leftCol);
                    }
                }
            }
            //If that checks the right col of the button
            if (rightCol < 10)
            {
                if (board.BoolBoard[row, rightCol] == false && board.ButtonBoard[row, rightCol].Visible == true)
                {
                    board.ButtonBoard[row, rightCol].Visible = false;
                    if (board.PanelBoard[row, rightCol].BackColor == Color.White)
                    {
                        ClearAdjacentButtons(row, rightCol);
                    }
                }
            }
        }

        /// <summary>
        /// Check Button total to see if the visible buttons left is 10 in order to decide if the game is won or not
        /// </summary>
        public void CheckButtonTotal()
        {
            for (int row = 0; row < board.ButtonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < board.ButtonBoard.GetLength(1); col++)
                {
                    if (board.ButtonBoard[row, col].Visible == false && board.BoolBoard[row, col] == false)
                    {
                        buttonTotal--;
                    }
                }
            }
    }

        /// <summary>
        /// Game logic method that sets up the panels and adjacent panel numbers
        /// </summary>
        public void GameLogic()
        {
            MinePanelSetUp();
            AdjacentPanelSetUp();
        }

        /// <summary>
        /// Method that randomizes where the mines are placed and gives corresponding image
        /// </summary>
        public void MinePanelSetUp()
        {
            while (numberOfMines > 0)
            {

                int row = random.Next(0, 10);
                int col = random.Next(0, 10);

                if (board.BoolBoard[row, col] == false)
                {
                    board.PanelBoard[row, col].BackgroundImage = Image.FromFile("Mine.png");
                    board.PanelBoard[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    board.BoolBoard[row, col] = true;
                    numberOfMines--;
                }
            }
            numberOfMines = 10;
        }

        /// <summary>
        /// Adjacent panel setup to set up the panels that do not have the mines with a simple white back color or a number corresponding to the mines
        /// </summary>
        public void AdjacentPanelSetUp()
        {
            int adjacentCount = 0;

            //For loops iterate through the panelBoard
            for (int row = 0; row < board.PanelBoard.GetLength(0); row++)
            {
                for (int col = 0; col < board.PanelBoard.GetLength(1); col++)
                {
                    if (board.BoolBoard[row,col] == false)
                    {
                        int rowSet = row - 1;
                        int colSet = col - 1;
                        int rowTest = row + 2;
                        int colTest = col + 2;

                        //For loops to iterate through the surrounding buttons based on previous math
                        for (int adjacentRows = rowSet; adjacentRows < rowTest; adjacentRows++)
                        {
                            for (int adjacentCols = colSet; adjacentCols < colTest; adjacentCols++)
                            {
                                if (adjacentRows != -1 && adjacentCols != -1 && adjacentRows != 10 && adjacentCols != 10)
                                {
                                    if (board.BoolBoard[adjacentRows, adjacentCols] == true)
                                    {
                                        adjacentCount++;
                                    }
                                }
                            }
                        }
                    }
                    //Depending on the amount of mines flagged gives number based on count
                    if (adjacentCount != 0)
                    {
                        board.PanelBoard[row, col].BackgroundImage = Image.FromFile($"Number{adjacentCount}.png");
                        board.PanelBoard[row, col].BackgroundImageLayout = ImageLayout.Stretch;
                    }
                    //If it has no adjacent mines simply sets to white
                    else
                    {
                        board.PanelBoard[row, col].BackColor = Color.White;

                    }
                    adjacentCount = 0;
                }
            }
        }

        /// <summary>
        /// Reset game method that removes each board and rebuilds the boards
        /// </summary>
        /// <param name="Controls">Controls to add new panels and buttons</param>
       public void ResetGame(Control.ControlCollection Controls)
        {
            for (int row = 0; row < board.ButtonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < board.ButtonBoard.GetLength(1); col++)
                {
                    Controls.Remove(board.PanelBoard[row, col]);
                    Controls.Remove(board.ButtonBoard[row, col]);
                }
            }
            board = new GameBoard();
            BuildGameBoard(Controls);
            GameLogic();

        }

        /// <summary>
        /// On timer tick handler that handles each tick and updates the made textbox
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> guess args </param>
        public void OnTimerTick(object sender, EventArgs e)
        {
            time = time.Add(TimeSpan.FromSeconds(1));
            textbox.Text = ($"Timer: {time}");
        }

        /// <summary>
        /// Clear all buttons method to set all buttons invisible once the game is over
        /// </summary>
        public void ClearAllButtons()
        {
            for (int row = 0; row < board.ButtonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < board.ButtonBoard.GetLength(1); col++)
                {
                    board.ButtonBoard[row, col].Visible = false;
                }
            }
        }

        /// <summary>
        /// Calculate statistics method that creates reader to read from file already made then writes to file based on integers taken from text
        /// </summary>
        public void CalculateStatistics()
        {
            //Creation of variables
            int winAmount = 0;
            int lossAmount = 0;

            //Creation of new timespan to add other timespan to
            TimeSpan readTime = new TimeSpan();

            //Creation of streamreader and based on if the file is completely empty or not reads it or not
            StreamReader reader = new StreamReader("Stats.txt");
            if (!reader.EndOfStream)
            {
                //If the win is true reads the same things but increments the wins
                if (win == true)
                {
                    winAmount = int.Parse(reader.ReadLine());
                    winAmount++;
                    lossAmount = int.Parse(reader.ReadLine());
                    readTime = TimeSpan.Parse(reader.ReadLine());
                    readTime = readTime + time;
                    readTime = readTime / 2;
                }
                //If not a win it increments the loss instead
                else
                {
                    winAmount = int.Parse(reader.ReadLine());
                    lossAmount = int.Parse(reader.ReadLine());
                    lossAmount++;
                    readTime = TimeSpan.Parse(reader.ReadLine());
                    readTime = readTime + time;
                    readTime = readTime / 2;
                }
            }
            //CLoses reader in order to write
            reader.Close();

            //Writes various calculated variables to file then closes writer for future reading or writing
            StreamWriter writer = new StreamWriter("Stats.txt");
            writer.WriteLine(winAmount.ToString());
            writer.WriteLine(lossAmount.ToString());
            writer.WriteLine(readTime.ToString());
            writer.Close();

        }

    }
}
