using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Game.Objects;

namespace GameProject.Elements
{
    class Player// player contains all informations, its like save
    {
         String name;
        public UsrShip UserShip;



        public Player(String _name)
        {
            name = _name;
        }

        // need to make constructor to loading save from file


    }
}
