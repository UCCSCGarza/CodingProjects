using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Dragon Class to represent entity dragon
    /// </summary>
    public class Dragon : Character
    {

        //Dragon constructor that gives dragon various stats upon creation
        public Dragon()
        {
            health = 200;
            ad = 25;
            ap = 25;
            defense = 50;
            magicDefense = 50;
            speed = 10;
            stance = false;
            skillPoints = 5;
            target = null;
        }

        /// <summary>
        /// Swipe attack that takes each hero and subtracts ad
        /// Cannot be defended
        /// </summary>
        /// <returns> attackAmount </returns>
        public uint SwipeAttack(Character[] heros )
        {
            uint attackAmount = 0;
            for ( int i = 0; i < heros.Length; i++)
            {
                heros[i].Health = heros[i].Health - ad;
                attackAmount = attackAmount + ad;
                if (heros[i].Health > 100)
                {
                    heros[i].Health = 0;
                }
            }
            skillPoints--;
            return attackAmount;
        }

        /// <summary>
        /// Breathe Fire Attack that takes target and applies double ap damage to target
        /// Cannot be defended.
        /// </summary>
        /// <returns> attackAmount </returns>
        public uint BreatheFire()
        {
            uint attackAmount;
            target.Health = target.Health - (ap * 2);
            if (target.Health > 100)
            {
                target.Health = 0;
            }
            attackAmount = ap * 2;
            skillPoints--;
            return attackAmount;
        }
    }
}