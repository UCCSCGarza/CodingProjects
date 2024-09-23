using cgarzaCS3020Project.Properties;
using System.Diagnostics.Eventing.Reader;
using System.DirectoryServices.ActiveDirectory;

namespace cgarzaCS3020Project
{
    public partial class GameInterface : Form
    {
        //GameInterface variables such as gamelogic and character
        public GameLogic game = new GameLogic();
        Character warrior = new Warrior();
        Character mage = new Mage();
        Character cleric = new Cleric();
        bool actionSelected = false;

        /// <summary>
        /// Game interface constructor that initializes, sets events and handlers, and creates a new game.
        /// </summary>
        public GameInterface()
        {
            InitializeComponent();
            game.EnemyChanged += enemyChangedHandler;
            game.PartyStatsChanged += partyStatsChangedHandler;
            game.displayResult += displayResultHandler;
            game.displayNewTurn += displayTurnHandler;
            game.statsChanged += updateStatsHandler;
            game.lostEvent += lostEventHandler;
            game.newGame();
        }

        /// <summary>
        /// Action click method that takes in the sender and eventargs to decide which action was clicked then set the selected character to do that action
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args e </param>
        private void action_Click(object sender, EventArgs e)
        {
            //If the sender is the attack button enables all the enemies to be clicked and sets the attack stance also disables heros
            if (sender == attackButton)
            {
                game.setAttackStance();
                mageBox.Enabled = false;
                warriorBox.Enabled = false;
                clericBox.Enabled = false;
                enemy1.Enabled = true;
                enemy2.Enabled = true;
                enemy3.Enabled = true;
                actionSelected = true;
            }

            //If the sender is the defend button sets the character to defend stance
            else if (sender == defendButton)
            {
                game.setDefendStance();
            }

            //If the sender is the heal button sets the character to the heal stance
            else if (sender == healButton)
            {
                game.setHealStance();
            }
            //If the sender is the endTurnButton runs the turns
            else if (sender == endTurnButton)
            {
                game.RunTurns();
            }

            //Once all is done disables all the buttons again for future use
            attackButton.Enabled = false;
            defendButton.Enabled = false;
            healButton.Enabled = false;
        }

        /// <summary>
        /// Picture box click handler that handles various clicks of the heros
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> event args e </param>
        private void pictureBox_Click(object sender, EventArgs e)
        {
            //If the picture box click is the warrior box then sets the character to warrior and makes border to show he was chosen
            //then enables the buttons that a warrior can do. If the character is dead by the canBeSelected bool tells user the hero is dead.
            bool canBeSelected = false;

            if (sender == warriorBox)
            {
                warriorBox.BorderStyle = BorderStyle.Fixed3D;
                canBeSelected = game.setCharacter(warrior);
                if (canBeSelected == true)
                {
                    attackButton.Enabled = true;
                    defendButton.Enabled = true;
                    healButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Your Hero is Dead!");
                }
            }
            else if (sender == mageBox)
            {
                mageBox.BorderStyle = BorderStyle.Fixed3D;
                canBeSelected = game.setCharacter(mage);
                if (canBeSelected == true)
                {
                    attackButton.Enabled = true;
                    defendButton.Enabled = true;
                    healButton.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Your Hero is Dead!");
                }
            }
            else if (sender == clericBox)
            {
                clericBox.BorderStyle = BorderStyle.Fixed3D;
                canBeSelected = game.setCharacter(cleric);

                if (canBeSelected == true)
                {
                    attackButton.Enabled = true;
                    defendButton.Enabled = true;
                    healButton.Enabled = true;
                }
                else
                {
                    MessageBox.Show("Your Hero is Dead!");
                }
            }

            //Once complete the border style is changed to none
            warriorBox.BorderStyle = BorderStyle.None;
            clericBox.BorderStyle = BorderStyle.None;
            mageBox.BorderStyle = BorderStyle.None;

        }

        /// <summary>
        /// Enemy changed handler that once the enemy is changed on the logic side changes the image on this side
        /// </summary>
        /// <param name="sender"> object sender </param>
        /// <param name="e"> eventargs e </param>
        private void enemyChangedHandler(object sender, GameProperties e)
        {
            //Puts all the enemy picture boxes in a array
            PictureBox[] pictureboxes = new PictureBox[] { enemy1, enemy2, enemy3 };

            //For loop to iterate thorugh the picture box
            for (int i = 0; i < pictureboxes.Length;)
            {
                //For loop to iterate through the bandit count and if there is a bandit increments the initial for loop
                for (int j = 0; j < e.BanditCount; j++)
                {
                    pictureboxes[i].Image = Image.FromFile("Bandit.png");
                    i++;
                }
                //Same as above but for the ogre count
                for (int j = 0; j < e.OgreCount; j++)
                {
                    pictureboxes[i].Image = Image.FromFile("Ogre.png");
                    i++;
                }
                //Same as above but for the dragon count
                for (int j = 0; j < e.DragonCount; j++)
                {
                    pictureboxes[i].Image = Image.FromFile("Dragon.png");
                    i++;
                }
            }
        }

        /// <summary>
        /// Enemy picture box click handler that allows clicks once a hero and action is selected
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void enemyPictureBox_Click(Object sender, EventArgs e)
        {
            //If sender is enemy1 sets the characters target and sets borderstyle to show selection
            if (actionSelected == true)
            {
                if (sender == enemy1)
                {
                    game.setTarget(game.getCorrespondingCharacter(1));
                    enemy1.BorderStyle = BorderStyle.Fixed3D;
                }
                //Repeats for enemy2
                else if (sender == enemy2)
                {
                    game.setTarget(game.getCorrespondingCharacter(2));
                    enemy2.BorderStyle = BorderStyle.Fixed3D;
                }
                //Repeats for enemy3
                else if (sender == enemy3)
                {
                    game.setTarget(game.getCorrespondingCharacter(3));
                    enemy3.BorderStyle = BorderStyle.Fixed3D;
                }
            }
            //Disables the pictureboxes and resets all borders
            //Enables the heros to be selected again also and resets buttons
            enemy1.BorderStyle = BorderStyle.None;
            enemy2.BorderStyle = BorderStyle.None;
            enemy3.BorderStyle = BorderStyle.None;
            enemy1.Enabled = false;
            enemy2.Enabled = false;
            enemy3.Enabled = false;
            mageBox.Enabled = true;
            warriorBox.Enabled = true;
            clericBox.Enabled = true;
            attackButton.Enabled = false;
            defendButton.Enabled = false;
            healButton.Enabled = false;
        }

        /// <summary>
        /// Handler that every time the party stats are updated takes all the enemies and heros and updates their stats for the user to see
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void partyStatsChangedHandler(object sender, Character[] e)
        {

            //Takes character arrays and updates party stats
            partyTextbox.Text = " Char:\t\tHealth:\tSP:\n";
            for (int i = 0; i < e.Length; i++)
            {
                if (e[i].Health != 0)
                {
                    partyTextbox.AppendText($" {e[i].GetType().Name}\t\t{e[i].Health}\t{e[i].SkillPoints}\n");
                }
                else
                {
                    partyTextbox.AppendText($" {e[i].GetType().Name}\t\t0\t{e[i].SkillPoints}\n");
                }
            }
        }

        /// <summary>
        /// Display result handler that takes the updateactionsargs and displays what happened
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> updateactionsargs e </param>
        public async void displayResultHandler(object sender, UpdateActionsArgs e)
        {
            //If the heal bool is not false checks for which attack is present then displays attack

            if (e.HealBool == false)
            {
                if (e.Damage != 0 && e.SwipeBool == false && e.FireBool == false)
                {
                    actionTextbox.AppendText($"{e.Character.GetType().Name} attacked {e.Target.GetType().Name} for {e.Damage} damage\n");
                }
                else if (e.Damage == 0)
                {
                    actionTextbox.AppendText($"{e.Target.GetType().Name} defended an attack from {e.Character.GetType().Name}\n");
                }
                else if (e.SwipeBool == true)
                {
                    actionTextbox.AppendText($"{e.Character.GetType().Name} swipe attacked all heros\n");

                }
                else if (e.FireBool == true)
                {
                    actionTextbox.AppendText($"{e.Character.GetType().Name} breathed fire on {e.Target.GetType().Name}\n");
                }

                //For each character from given array checks if the character is dead and flags deadbool on that character
                for (int i = 0; i < e.Characters.Length; i++)
                {
                    if (e.Characters[i].Health == 0 && e.Characters[i].DeadBool == false)
                    {
                        actionTextbox.AppendText($"{e.Characters[i].GetType().Name} died!\n");
                        e.Characters[i].DeadBool = true;
                    }
                }
            }

            //If the heal is selected displays heal
            else
            {
                actionTextbox.AppendText($"{e.Character.GetType().Name} healed all heros!\n");
            }
        }

        /// <summary>
        /// Display Turn Handler just tells when the results are ended at end of the turn
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void displayTurnHandler(object sender, EventArgs e)
        {
            actionTextbox.AppendText("(End of Results)\n\n");
        }

        /// <summary>
        /// Made by tool strip to show a messagebox about developer and class
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void madeByToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Made By: Chris Garza\nClass: CS3020");
        }

        /// <summary>
        /// Restart tool strip handler that restarts the game
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            game.newGame();
            endTurnButton.Enabled = true;
        }

        /// <summary>
        /// Exit tool strip handler that exits the environment
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        /// <summary>
        /// Instructions menu handler that displays instructions in messagebox
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void instructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Instructions:\n Please select a character in order to enable which actions a character has!" +
                "\n Select an action to use on an enemy or defend" +
                "\n Defending will simply put your character in a defense stance with a chance to block an attack!" +
                "\n Attacking will attack the enemy you select, but cannot attack heros!" +
                "\n TIP!!! Mages do more damage to Ogres!" +
                "\n If you select heal as cleric every hero is healed!" +
                "\n Careful! Your Cleric has a limited number of points to heal!" +
                "\n If you do not select an action, but end the turn your characters will defend!" +
                "\n Every action is displayed in the action textbox on the bottom right!" +
                "\n Every character's stats are displayed in the middle textbox!" +
                "\n You must figure out the enemies actions!" +
                "\n Once the turns are ran every character has a set speed in which they will carry out their actions!" +
                "\n Good luck!");
        }

        /// <summary>
        /// Update stats handler that takes the gamestats and updates the file if the scores are higher
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void updateStatsHandler(object sender, GameStats e)
        {
            //Opens streamreader and takes highscore and levelscompleted
            StreamReader streamReader = new StreamReader("Stats.txt");
            int highscore = int.Parse(streamReader.ReadLine());
            int levelsCompleted = int.Parse(streamReader.ReadLine());

            streamReader.Close();

            //Opens streamwriter to write new highscore and levels completed
            StreamWriter streamWriter = new StreamWriter("Stats.txt");

            //If the highschore is higher changes the highscore else keeps the same
            if (e.HighScore > highscore)
            {
                streamWriter.WriteLine(e.HighScore);
            }
            else
            {
                streamWriter.WriteLine(highscore);
            }

            //If the levelscompleted is higher changes the levels completed else keeps the same
            if (e.LevelsCompleted > levelsCompleted)
            {
                streamWriter.WriteLine(e.LevelsCompleted);
            }
            else
            {
                streamWriter.WriteLine(levelsCompleted);
            }

            streamWriter.Close();

        }

        /// <summary>
        /// Stats menu clicked handler that takes the stats file and displays the stats 
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void statsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Opens streamreader then reads the stats into a messagebox and closes the reader
            StreamReader reader = new StreamReader("Stats.txt");
            MessageBox.Show($"Highscore: {reader.ReadLine()}\n Levels Completed: {reader.ReadLine()}");
            reader.Close();
        }

        /// <summary>
        /// When the game is lost disables endturnButton and only lets user use menu strip
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="e"> eventargs e </param>
        private void lostEventHandler(object sender, EventArgs e)
        {
            endTurnButton.Enabled = false;
        }
    }
}
