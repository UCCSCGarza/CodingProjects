using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Mage class that defines the mage character
    /// </summary>
    public class Mage : Character
    {
        //Mage constructor that gives mage predefined stats
        public Mage()
        {
            health = 100;
            ad = 0;
            ap = 25;
            defense = 10;
            magicDefense = 50;
            speed = 15;
            stance = false;
            skillPoints = 0;
        }
    }
}