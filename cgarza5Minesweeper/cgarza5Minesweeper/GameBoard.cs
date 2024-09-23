using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cgarza5Minesweeper
{
    /// <summary>
    /// Gameboard class that contains panelboards, buttonboards, and boolboards
    /// </summary>
    internal class GameBoard : EventArgs
    {
        //Various arrays
        private Panel[,] panelBoard;
        private Button[,] buttonBoard;
        private bool[,] boolBoard;

        /// <summary>
        /// Gameboard constructor that sets each array
        /// </summary>
        public GameBoard()
        {
            panelBoard = new Panel[10, 10];
            buttonBoard = new Button[10, 10];
            boolBoard = new bool[10, 10];
        }

        /// <summary>
        /// Contains method to check if the array contains the specified button
        /// </summary>
        /// <param name="button"> button to be checked</param>
        /// <returns></returns>
        public bool Contains(Button button)
        {
            bool containBool = false;

            foreach (Button compareButton in  buttonBoard)
            {
                if (compareButton.Equals(button))
                {
                    containBool = true;
                }
            }


            return containBool;
        }

        /// <summary>
        /// Get button row that iterates through board to find the button and gives the row
        /// </summary>
        /// <param name="button"> Button to be checked </param>
        /// <returns></returns>
        public int GetButtonRow(Button button)
        {
            int returnRow = 0;

            for (int row = 0; row < buttonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < buttonBoard.GetLength(1); col++)
                {
                    if (buttonBoard[row, col].Equals(button)) { returnRow = row; }

                }
            }

            return returnRow;
        }

        /// <summary>
        /// Get button col that iterates through board to find the button and give the column
        /// </summary>
        /// <param name="button"> button to be checked </param>
        /// <returns></returns>
        public int GetButtonCol(Button button)
        {
            int returnCol = 0;

            for (int row = 0; row < buttonBoard.GetLength(0); row++)
            {
                for (int col = 0; col < buttonBoard.GetLength(1); col++)
                {
                    if (buttonBoard[row, col].Equals(button)) { returnCol = col; }

                }
            }

            return returnCol;
        }

        /// <summary>
        /// Various array getters and setters
        /// </summary>
        public Panel[,] PanelBoard { get => panelBoard; set => panelBoard = value; }
        public Button[,] ButtonBoard { get => buttonBoard; set => buttonBoard = value; }

        public bool[,] BoolBoard { get => boolBoard; set => boolBoard = value; }
    }
}
