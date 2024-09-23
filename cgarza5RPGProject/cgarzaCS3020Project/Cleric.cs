using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Cleric class that defines the cleric character.
    /// </summary>
    public class Cleric : Character
    {
        //Specific stance only the cleric has.
        protected bool healStance = false;
        protected uint healAmount;

        //Constructor that gives cleric predefined stats.
        public Cleric()
        {
            healAmount = 25;
            health = 100;
            ad = 10;
            ap = 0;
            defense = 25;
            magicDefense = 25;
            speed = 25;
            stance = false;
            skillPoints = 3;
        }

        /// <summary>
        /// Heal method (Not implemented Yet).
        /// </summary>
        /// <returns></returns>
        public void Heal(Character[] heros)
        {
            for (int i = 0; i < heros.Length; i++)
            {
                if (heros[i].Health != 0 && heros[i].Health != 100)
                {
                    heros[i].Health = heros[i].Health + healAmount;
                }
            }
            skillPoints--;
        }

        //Heal stance getter and setter
        public bool HealStance { get => healStance; set => healStance = value; }

        public int SkillPoints { get => skillPoints; set => skillPoints = value; }
    }
}