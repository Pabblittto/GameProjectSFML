using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Game.Objects
{
    class UsrShip:Drawable // movable ship which is displaed on screen
    {
        RectangleShape ShipRectangle;


        public UsrShip(Ship ShipUsedByPlayer)
        {
            // SpipRectangle set by ShipUsedByPlayer
        }

        public void Draw(RenderTarget window,RenderStates states)
        {

        }


    }
}
