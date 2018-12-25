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
    class UsrShip:Ship // movable ship which is displaed on screen
    {


        public UsrShip(Vector2f SizeOfShip, uint CrewAmount, uint TrunkAmount, uint CanoonAmount, string TexturePath,string TexttureSideShip, Vector2f positionOfShip, float Degree,float mass,float maxspeed) :base(SizeOfShip,CrewAmount,TrunkAmount,CanoonAmount,TexturePath,TexttureSideShip,positionOfShip,Degree,mass,maxspeed)
        {
            
        }




    }
}
