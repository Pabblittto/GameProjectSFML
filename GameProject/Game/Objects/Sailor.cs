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
    class Sailor// class for making possible members of player's crew
    {
         String name;
        float CanoonReloading;
        float HoldLoading;// two variables presented in percent
                          // it means how these activities are faster

        public Sailor(float CanoonPercent, float HoldPercent, String _name,String filePath)
        {

            HoldLoading = HoldPercent;
        }
           
    }
}
