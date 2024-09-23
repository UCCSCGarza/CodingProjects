using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Game logic class that handles all the characters and everything else on the non-interface side
    /// </summary>
    public class GameLogic
    {
        //Construction of heros
        protected Warrior warrior = new Warrior();
        protected Mage mage = new Mage();
        protected Cleric cleric = new Cleric();

        //Definement of enemies
        protected Character enemy1;
        protected Character enemy2;
        protected Character enemy3;

        //Creation of selected character bools
        bool mageBool = false;
        bool warriorBool = false;
        bool clericBool = false;

        public bool ClericBool { get => clericBool; set => clericBool = value; }

        public bool WarriorBool { get => warriorBool; set => warriorBool = value; }

        public bool MageBool { get => mageBool; set => mageBool = value; }

        //Definement of updateactionsargs
        protected UpdateActionsArgs turnArgs;

        //Definement of GameStats
        protected GameStats gameStats;

        //Creation of events
        public event EventHandler<GameProperties>? EnemyChanged;
        public event EventHandler<Character[]>? PartyStatsChanged;
        public event EventHandler<UpdateActionsArgs>? displayResult;
        public event EventHandler<EventArgs>? displayNewTurn;
        public event EventHandler<GameStats>? statsChanged;
        public event EventHandler<EventArgs>? lostEvent;

        //Creation of game properties
        protected GameProperties GameProperties = new GameProperties();

        /// <summary>
        /// Get corresponding character method that returns enemy corresponding to integer given
        /// </summary>
        /// <param name="enemy"> integer to find which enemy needs to be given </param>
        /// <returns></returns>
        public Character getCorrespondingCharacter(int target)
        {
            if (target == 1)
            {
                return enemy1;
            }
            else if (target == 2)
            {
                return enemy2;
            }
            else if (target == 3)
            {
                return enemy3;
            }
            else if (target == 4)
            {
                return warrior;
            }
            else
            {
                return mage;
            }
        }

        /// <summary>
        /// setCharacter method that gets the character type then sets the chosen character bool
        /// </summary>
        /// <param name="character"> character to compare to </param>
        public bool setCharacter(Character character)
        {
            //If statement that takes the character and matches it to which type it is then sets the bool to whichever character has been selected
            //If the character cannot be selected returns false bool for interface
            bool canBeSelected = true;

            if (character.GetType() == typeof(Warrior))
            {
                if (warrior.Health == 0)
                {
                    canBeSelected = false;
                }
                else
                {
                    warriorBool = true;
                }
            }
            else if (character.GetType() == typeof(Mage))
            {
                if (mage.Health == 0) 
                {
                    canBeSelected = false;
                }
                else
                {
                    mageBool = true;
                }
            }
            else if (character.GetType() == typeof(Cleric))
            {
                if (cleric.Health == 0)
                {
                    canBeSelected = false;
                }
                else
                {
                    clericBool = true;
                }
            }

            return canBeSelected;
        }

        /// <summary>
        /// setTarget method that takes the enemy/hero character that was selected and based on the hero selected (By the bool updated before) makes their
        /// action target the character given.
        /// </summary>
        /// <param name="character"> Character chosen to target </param>
        public void setTarget(Character character)
        {
            //Checks to see if the enemy is dead if so then tells the user and prompts for a re-select (also resets stances)
            if (character.Health == 0)
            {
                MessageBox.Show("Character is dead! Please re-select!");
                if (warriorBool)
                {
                    warrior.Stance = false;
                }
                else if (clericBool)
                {
                    cleric.Stance = false;
                }
                else
                {
                    mage.Stance = false;
                }

            }

            //Else if the warrior bool is true changes target
            else if (warriorBool == true)
            {
                warrior.Target = character;
            }

            //Else if the cleric bool is true changes target
            else if (clericBool == true)
            {
                cleric.Target = character;
            }
            //Else if the mage bool is true changes target
            else if (mageBool == true)
            {
                mage.Target = character;
            }

            //Bools set to false after the target is selected
            warriorBool = false;
            mageBool = false;
            clericBool = false;
        }

        /// <summary>
        /// Attack stance method that sets the stance to attack based on which character is selected for attack
        /// </summary>
        public void setAttackStance()
        {
            if (warriorBool)
            {
                warrior.setStance(true);
            }
            else if (mageBool)
            {
                mage.setStance(true);
            }
            else if (clericBool)
            {
                cleric.setStance(true);
            }
        }

        /// <summary>
        /// Defend stance method that sets the stance to defend based on which character is selected for defense.
        /// </summary>
        public void setDefendStance()
        {
            if (warriorBool)
            {
                warrior.setStance(false);
            }
            else if (mageBool)
            {
                mage.setStance(false);
            }
            else if (clericBool)
            {
                cleric.setStance(false);
            }
            warriorBool = false;
            mageBool = false;
            clericBool = false;
        }

        /// <summary>
        /// Heal stance method that sets the cleric heal stance to true unless the cleric is out of skillpoints
        /// </summary>
        public void setHealStance()
        {
            if (cleric.SkillPoints != 0)
            {
                cleric.HealStance = true;
                cleric.Stance = false;
            }
            else
            {
                MessageBox.Show("Cleric is out of skill points! Cannot heal party!");
            }
            warriorBool = false;
            mageBool = false;
            clericBool = false;
        }

        /// <summary>
        /// New game method that starts a new game at level 1, makes the level, and sets the stats. The overall stats are also remade
        /// </summary>
        public void newGame()
        {
            GameProperties.Level = 1;
            gameStats = new GameStats();
            newLevel();
        }

        /// <summary>
        /// Set enemies method that nulls the enemies for a new level then constructs them based on the level and counts of each enemy
        /// </summary>
        public void setEnemies()
        {
            //Sets enemies to null then puts them into a array
            enemy1 = null;
            enemy2 = null;
            enemy3 = null;
            Character[] enemies = new Character[3];

            //For loop that iterates through the array
            for (int enemy = 0; enemy < enemies.Length;)
            {
                //For loop that sets the character to a bandit based on count then increments beginning loop
                for (int i = 0; i < GameProperties.BanditCount; i++)
                {
                    enemies[enemy] = new Bandit();
                    enemy++;
                }
                //Same as previous but for the ogre count
                for (int i = 0; i < GameProperties.OgreCount; i++)
                {
                    enemies[enemy] = new Ogre();
                    enemy++;
                }
                //Same as previous but for the Dragon Count
                for (int i = 0; i < GameProperties.DragonCount; i++)
                {
                    enemies[enemy] = new Dragon();
                    enemy++;
                }
            }
            //Sets the enemy 1, 2, and 3 to the arrays set enemies since the array will be deleted
            enemy1 = enemies[0];
            enemy2 = enemies[1];
            enemy3 = enemies[2];

            //Calls on new enemies
            OnNewEnemies(this, GameProperties);
        }

        /// <summary>
        /// On new enemies method that raises the enemychanged event
        /// </summary>
        /// <param name="sender"> seneder object </param>
        /// <param name="e"> game properties args e </param>
        public void OnNewEnemies(object sender, GameProperties e)
        {
            EnemyChanged?.Invoke(sender, e);
        }

        /// <summary>
        /// Make level class with predefined counts of enemies for levels until 10 which will then repeat the same level.
        /// </summary>
        public void MakeLevel()
        {
            //If statements to check which level and then gives corresponding counts predetermined by developer
            if (GameProperties.Level == 1)
            {
                GameProperties.BanditCount = 3;
                GameProperties.OgreCount = 0;
                GameProperties.DragonCount = 0;
            }
            else if (GameProperties.Level == 2)
            {
                GameProperties.BanditCount = 2;
                GameProperties.OgreCount = 1;
                GameProperties.DragonCount = 0;
            }
            else if (GameProperties.Level == 3)
            {
                GameProperties.BanditCount = 1;
                GameProperties.OgreCount = 2;
                GameProperties.DragonCount = 0;
            }
            else if (GameProperties.Level == 4)
            {
                GameProperties.BanditCount = 0;
                GameProperties.OgreCount = 3;
                GameProperties.DragonCount = 0;
            }
            else if (GameProperties.Level == 5)
            {
                GameProperties.BanditCount = 2;
                GameProperties.OgreCount = 0;
                GameProperties.DragonCount = 1;
            }
            else if (GameProperties.Level == 6)
            {
                GameProperties.BanditCount = 1;
                GameProperties.OgreCount = 1;
                GameProperties.DragonCount = 1;
            }
            else if (GameProperties.Level == 7)
            {
                GameProperties.BanditCount = 0;
                GameProperties.OgreCount = 2;
                GameProperties.DragonCount = 1;
            }
            else if (GameProperties.Level == 8)
            {
                GameProperties.BanditCount = 0;
                GameProperties.OgreCount = 1;
                GameProperties.DragonCount = 2;
            }
            else if (GameProperties.Level == 9)
            {
                GameProperties.BanditCount = 0;
                GameProperties.OgreCount = 0;
                GameProperties.DragonCount = 3;
            }
            else if (GameProperties.Level == 10)
            {
                GameProperties.BanditCount = 0;
                GameProperties.OgreCount = 0;
                GameProperties.DragonCount = 3;
            }

            //Set enemies method is then called
            setEnemies();
        }

        /// <summary>
        /// Run turns method that once the end turn button is clicked runs the turns
        /// </summary>
        public void RunTurns()
        {
            //Calls the set enemy choices method which sets the enemies targets and stance on random
            setEnemyChoices();

            //Calls create turn order method to create an array of characters based on speed
            Character[] characters = CreateTurnOrder();

            //integer to track the attack amount
            uint attackAmount = 0;
            bool healBool = false;
            bool fireBool = false;
            bool swipeBool = false;

            //For loop to iterate through the array 
            for (int i = 0; i < characters.Length; i++)
            {
                //If the stance is attack calls the attack method and sets the attackAmount to that
                if (characters[i].Stance == true && characters[i].Health != 0)
                {
                    attackAmount = characters[i].Attack();

                    //Sets the turnargs
                    turnArgs = new UpdateActionsArgs(attackAmount, characters[i], characters[i].Target, healBool, fireBool, swipeBool, characters);

                    //Displays results
                    displayResult?.Invoke(this, turnArgs);
                }
                //If the character is a cleric checks heal stance then heals all heros and
                else if (characters[i] is Cleric)
                {
                    if (cleric.HealStance == true)
                    {
                        //Creates character array to give to heal method
                        Character[] heros = new Character[] { warrior, mage, cleric };
                        cleric.Heal(heros);
                        healBool = true;

                        //Sets turnargs
                        turnArgs = new UpdateActionsArgs(attackAmount, characters[i], characters[i].Target, healBool, fireBool, swipeBool, characters);

                        //Displays results
                        displayResult?.Invoke(this, turnArgs);
                    }
                }
                //If the character is a dragon checks stances dragon could have
                else if (characters[i] is Dragon dragon)
                {
                    //Checks fire stance
                    if (characters[i].FireStance == true)
                    {
                        //Sets attackamount to amount taken from breathefire and sets bool to true 
                        attackAmount = dragon.BreatheFire();
                        fireBool = true;

                        //Sets turnargs
                        turnArgs = new UpdateActionsArgs(attackAmount, characters[i], characters[i].Target, healBool, fireBool, swipeBool, characters);

                        //Displays results
                        displayResult?.Invoke(this, turnArgs);
                    }
                    //Else the stance is swipeattack
                    else
                    {
                        //Creates characters array to damage all heros
                        Character[] heros = new Character[] { warrior, mage, cleric };

                        //Takes attack amount from swipeattack method and updates bool to true
                        attackAmount = dragon.SwipeAttack(heros);
                        swipeBool = true;

                        //Updates turnargs and displays reults
                        turnArgs = new UpdateActionsArgs(attackAmount, characters[i], characters[i].Target, healBool, fireBool, swipeBool, characters);
                        displayResult?.Invoke(this, turnArgs);
                    }
                }
                //Resets all bools
                swipeBool = false;
                healBool = false;
                fireBool = false;
            }

            //Calls setpartystats method and endlevel method
            resetAllBools();
            setPartyStats();
            displayNewTurn?.Invoke(this, null);
            endLevel();
        }

        /// <summary>
        /// Resetallbools methods resets all bools on heros and resets targets
        /// </summary>
        public void resetAllBools()
        {
            mageBool = false;
            clericBool = false;
            warriorBool = false;

            cleric.HealStance = false;

            Character[] heros = new Character[] { warrior, mage, cleric };
            for (int i = 0; i < heros.Length; i++)
            {
                heros[i].Stance = false;
                heros[i].Target = null;
            }
        }

        /// <summary>
        /// Set enemy choices method to randomly create enemy attacks and defenses
        /// </summary>
        public void setEnemyChoices()
        {
            //Creation of arrays and random
            Character[] enemies = new Character[] {enemy1, enemy2, enemy3};
            Character[] heros = new Character[] { warrior, mage, cleric };
            Random random = new Random();

            //For loop to iterate through the enemies
            for (int i = 0; i < enemies.Length; i++)
            {
                //If the enemy is not dead
                if (enemies[i].Health != 0)
                {
                    //Receives a random integer deciding whether or not to attack
                    int attack = random.Next(0, 2);

                    //If chooses to attack checks if dragon or other enemy
                    if (attack == 1)
                    {
                        //if dragon sets all stances to false to check which stance to set to
                        if (enemies[i] is Dragon dragon)
                        {
                            dragon.FireStance = false;
                            dragon.SwipeStance = false;
                            dragon.Stance = false;

                            //While all the stances are false finds attack method and target
                            while (dragon.Stance == false && dragon.FireStance == false && dragon.SwipeStance == false)
                            {
                                //Gets attack from random to decide whether to swipe, fire breath, or regular attack
                                attack = random.Next(0, 3);
                                if (attack == 0)
                                {
                                    //sets stance then decides which target to attack
                                    enemies[i].Stance = true;
                                    attack = random.Next(0, 3);
                                    enemies[i].Target = heros[attack];

                                    //if the targets health is 0 keeps going until valid target is selected
                                    while (heros[attack].Health == 0)
                                    {
                                        attack = random.Next(0, 3);
                                        enemies[i].Target = heros[attack];
                                    }
                                }
                                else if (attack == 1 && dragon.SkillPoints > 0 )
                                {
                                    //sets stance if skillpoints are available then does same as previous to decide target
                                    enemies[i].FireStance = true;
                                    attack = random.Next(0, 3);
                                    enemies[i].Target = heros[attack];
                                    while (heros[attack].Health == 0)
                                    {
                                        attack = random.Next(0, 3);
                                        enemies[i].Target = heros[attack];
                                    }
                                }
                                else if (dragon.SkillPoints > 0)
                                {
                                    //if skillpoints are available sets swipestance to true and resets target to null since the target is every hero
                                    enemies[i].SwipeStance = true;
                                    dragon.Target = null;
                                }
                            }
                        }

                        //If the enemy is not a dragon just decides attack target based on previous method and sets stance
                        else
                        {
                            enemies[i].Stance = true;
                            attack = random.Next(0, 3);
                            enemies[i].Target = heros[attack];

                            while (heros[attack].Health == 0)
                            {
                                attack = random.Next(0, 3);
                                enemies[i].Target = heros[attack];
                            }
                        }
                    }
                    //If not the stance is set to false to defend
                    else
                    {
                        enemies[i].Stance = false;
                    }
                }
            }
        }

        /// <summary>
        /// Create turn order method that returns every enemy and hero in an array based on speed
        /// </summary>
        /// <returns> an array of enemies and characters based on speed </returns>
        public Character[] CreateTurnOrder()
        {
            //Creation of list to iterate through with given heros and enemies
            List<Character> characters = new List<Character>{ warrior, mage, cleric, enemy1, enemy2, enemy3 };

            //Creation of the sorted characters array based on length of list
            Character[] charactersSorted = new Character[characters.Count];

            //Creation of fastest character and fastestspeed int
            Character fastestCharacter = null;
            int fastestSpeed = 0;

            //For loop that takes for the length of the characters sorted array finds the fastest character and adds them to the array
            for (int i = 0; i < charactersSorted.Length; i++)
            {
                //Goes through the list to find the fastest character
                for (int j = 0; j < characters.Count; j++)
                {
                    //If the character has a faster speed than the fastest speed sets the fastest character to that character and the speed to that character
                    if (characters[j].Speed > fastestSpeed)
                    {
                        fastestSpeed = characters[j].Speed;
                        fastestCharacter = characters[j];
                    }
                }

                //Adds the character to sorted array once iterated and then removes that character from the list
                charactersSorted[i] = fastestCharacter;
                characters.Remove(fastestCharacter);

                //Resets variables
                fastestSpeed = 0;
                fastestCharacter = null;
            }

            //Returns sorted array of characters
            return charactersSorted;

        }

        /// <summary>
        /// New level method that resets the heros' healths and makes a new level. Parts stats are then displayed for that level
        /// </summary>
        public void newLevel() 
        {
            warrior.Health = 100;
            mage.Health = 100;
            cleric.Health = 100;
            cleric.SkillPoints = 3;
            MakeLevel();
            setPartyStats();
        }

        /// <summary>
        /// End level method that once called checks to see if all the enemies are dead then ends the level
        /// </summary>
        public void endLevel()
        {
            //Array of enemies for checking and integer to check dead count
            Character[] enemies = new Character[] { enemy1, enemy2, enemy3 };
            Character[] heros = new Character[] { warrior, mage, cleric };
            int dead = 0;
            int herosDead = 0;

            //For loop that goes through the enemies array and if dead increases counter
            for (int i = 0; i < enemies.Length; i++)
            {
                if (enemies[i].Health == 0)
                {
                    dead++;
                }
            }

            for (int i = 0; i < heros.Length; i++)
            {
                if (heros[i].Health == 0)
                {
                    herosDead++;
                }
            }

            //If the counter is 3 (Max enemies) and the level is not already 10 increments level then makes new level.
            if( dead == 3)
            {
                MessageBox.Show("Level Defeated! New Enemies Approaching!");
                if (GameProperties.Level != 10)
                {
                    GameProperties.Level++;
                    gameStats.LevelsCompleted++;
                    gameStats.HighScore = gameStats.HighScore + (int)( warrior.Health + mage.Health + cleric.Health);
                    gameStatsChanged(this, gameStats);
                }
                if (GameProperties.Level == 10)
                {
                    MessageBox.Show("You have defeated every level! Congratulations!!!\n You can continue fighting dragons or restart!");
                    gameStatsChanged(this,gameStats);
                }
                newLevel();
            }
            //If the counter is 3 (Max heros) tells the user that they lost a level and disables all buttons to allow user to restart, exit, or others
            else if (herosDead == 3)
            {
                gameStatsChanged(this, gameStats);
                MessageBox.Show($"You Lost at Level {GameProperties.Level}!");
                lostEvent.Invoke(this, null);
            }
        }

        /// <summary>
        /// When the game stats are changed updates text file by invoking event
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="gameStats"> gamestarts args </param>
        public void gameStatsChanged(object sender, GameStats gameStats)
        {
            statsChanged?.Invoke(sender, gameStats);
        }

        /// <summary>
        /// Restart game method that has not been implemented
        /// </summary>
        /// <exception cref="System.NotImplementedException"></exception>
        public void RestartGame()
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// set party stats method that creates an array of characters then calls onNewStats event
        /// </summary>
        public void setPartyStats()
        {
            Character[] characters = new Character[] { warrior, mage, cleric, enemy1, enemy2, enemy3 };
            onNewPartyStats(this, characters);
        }

        /// <summary>
        /// On new parts stats invokes partystatschanged to update interface textbox
        /// </summary>
        /// <param name="sender"> sender object </param>
        /// <param name="characters"> characters to use for updating stats </param>
        public void onNewPartyStats(object sender, Character[] characters)
        {
            PartyStatsChanged?.Invoke(this, characters);
        }
    }
}