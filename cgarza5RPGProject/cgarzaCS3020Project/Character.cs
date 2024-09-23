using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Character class that includes various variables with getters and setters for character stats
    /// </summary>
    public class Character
    {
        //Various stats that every character needs with getters and setters implemented
        protected Character target;
        public Character Target { get => target; set => target = value; }

        protected uint health;

        public uint Health { get => health; set => health = value; }

        protected int defense;
        public int Defense { get => defense; set => defense = value; }

        protected uint ad;
        public uint AD { get => ad; set => ad = value; }

        protected uint ap;
        public uint AP { get => ap; set => ap = value; }

        protected int magicDefense;
        public int MagicDefense { get => magicDefense; set => magicDefense = value; }

        protected int speed;
        public int Speed { get => speed; set => speed = value; }

        protected bool stance;
        public bool Stance { get => stance; set => stance = value; }

        protected int skillPoints;
        public int SkillPoints { get => skillPoints; set => skillPoints = value; }

        protected bool swipeStance = false;

        public bool SwipeStance { get => swipeStance; set => swipeStance = value; }

        protected bool fireStance = false;
        public bool FireStance { get => fireStance; set => fireStance = value; }

        protected bool deadBool = false;

        public bool DeadBool { get=> deadBool; set => deadBool = value; }

        /// <summary>
        /// Set stance method that takes a bool and sets the characters stance
        /// </summary>
        /// <param name="stanceBool"> bool given to switch stance to </param>
        public void setStance(bool stanceBool)
        {
            stance = stanceBool;
        }

        /// <summary>
        /// Attack method that takes whether or not the character is AD or AD then checks if the character defends the attack. If defended
        /// no damage is taken, but if not defended damage is taken. Then returns attack amount on target. If the uint goes to max it resets it to 0.
        /// </summary>
        /// <returns> attack amount on target </returns>
        public uint Attack()
        {
            uint attackAmount = 0;
            bool defended = false;
            if (ap > ad)
            {
                defended = getAPDefense();
                if (!defended)
                {
                    if (target.GetType() == typeof(Ogre))
                    {
                        target.Health = target.Health - (ap * 2);
                        if (target.Health > 200)
                        {
                            target.Health = 0;
                        }
                        attackAmount = ap * 2;
                    }
                    else
                    {
                        target.Health = target.Health - ap;
                        if (target.Health > 200)
                        {
                            target.Health = 0;
                        }
                        attackAmount = ap;
                    }
                }
            }
            else
            {
                defended = getADDefense();
                if (!defended)
                {
                    target.Health = target.Health - ad;
                    if (target.Health > 200)
                    {
                        target.Health = 0;
                    }
                    attackAmount = ad;
                }
            }
            return attackAmount;
        }

        /// <summary>
        /// Get AD defense method uses a random number generator from 0,100 then compares to the defense of the character if they are in the defense stance.
        /// If they are in the defense stance and the random number is equal to or less than their defense stat they defend the attack. AD and defense focused.
        /// </summary>
        /// <returns> returns defended bool </returns>
        public bool getADDefense()
        {
            Random random = new Random();
            bool defendedBool = false;
            int defended = 0;
            if (target.Stance == false)
            {
                defended = random.Next(0, 100);
                if (defended <= target.defense)
                {
                    defendedBool = true;
                }
            }
            return defendedBool;
        }

        /// <summary>
        /// Get AP defense method uses a random number generator from 0,100 then compares to the defense of the character if they are in the defense stance.
        /// If they are in the defense stance and the random number is equal to or less than their defense stat they defend the attack. AP and magic defense
        /// focused.
        /// </summary>
        /// </summary>
        /// <returns> returns defended bool </returns>
        public bool getAPDefense()
        {
            Random random = new Random();
            bool defendedBool = false;
            int defended = 0;
            if (target.Stance == false)
            {
                if (target is Ogre)
                {
                    defended = random.Next(0, 100);
                    if (defended <= (target.magicDefense/2))
                    {
                        defendedBool = true;
                    }
                }
                else
                {
                    defended = random.Next(0, 100);
                    if (defended <= target.magicDefense)
                    {
                        defendedBool = true;
                    }
                }
            }
            return defendedBool;
        }
    }
}