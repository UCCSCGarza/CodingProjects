using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace cgarzaCS3020Project
{
    /// <summary>
    /// Game Properties class to update level and enemy counts
    /// </summary>
    public class GameProperties
    {
        //Int variables to controls counts
        protected int dragonCount;
        protected int level;
        protected int ogreCount;
        protected int banditCount;


        //Getters and setters of all the values
        public int DragonCount
        {
            get => dragonCount; set => dragonCount = value;
        }

        public int Level
        {
            get => level; set => level = value;
        }

        public int OgreCount
        {
            get => ogreCount; set => ogreCount = value;
        }

        public int BanditCount
        {
            get => banditCount; set => banditCount = value;
        }
    }
}