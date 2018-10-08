using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using SFML;

namespace GameProject.Game.Objects
{
    class Map// map which is used by View object- its constructed by tiles 
    {       // it denfined how map is displayed and constructed
        private int[,] Matrix;
        private RectangleShape AllField;
        private Vector2f ShipPosition;


        public Map()
        {
            Matrix = new int[,] { {0,0,0,0,0,0},// 0 means water, 1 means land
                                  {0,0,0,0,0,0},
                                  {0,0,0,0,0,0},
                                  {0,0,0,0,0,1},
                                  {0,0,0,0,1,1},
                                  {0,0,0,1,1,1},
            };



        }






        

    }
}
