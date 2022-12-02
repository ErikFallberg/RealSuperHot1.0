using System;
using System.Collections.Generic;
using System.Text;

namespace RealSuperHot1._0
{
    abstract class Tile
    {
        public bool Passable { get; protected set; }
        public char Id { get; protected set; } 
        public Coordinate Coord { get; private set; }


        public Tile(Coordinate coord)
        {
            this.Coord = coord;
        }

        //abstract public void Attacked(char id); // Bool attacked? 
        
        //public char showId()
        //{
        //    // if (!attacked)
        //    //    return id;
        //    // else
        //    //    return id;
        //    //    set id;
        //    //    attack = !attacked; 
        //    return null;
        //}
        
    }
}
