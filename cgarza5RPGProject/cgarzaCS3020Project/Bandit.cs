using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Bandit class that defines a bandit character
    /// </summary>
    public class Bandit : Character
    {
        //Bandit constructor to give bandit preset stats
        public Bandit()
        {
            health = 50;
            ad = 25;
            ap = 0;
            defense = 10;
            magicDefense = 10;
            speed = 100;
            stance = false;
            skillPoints = 0;
        }
    }
}