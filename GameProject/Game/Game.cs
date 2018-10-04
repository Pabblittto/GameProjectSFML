using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using SFML.Audio;
using GameProject.Elements;
using GameProject.Game.Objects;

namespace GameProject.Game
{
    class GameObj: Frame// game is combined with many elements
    {
        
        

        Player User;
        UserInterface UserInterface;

        public GameObj()
        {

        }


        public void SetPlayer(Player userObj)//really important method- game need Player obiect, almost work like constructor
        {
            User = userObj;
            UserInterface = new UserInterface(User);

           
            
        }




        public override void Render(MyWindow window)
        {
            UserInterface.Render();


        }

        public override void CheckEvents(MyWindow window)
        {
            if (User == null)
            {
                throw new Exception();// Player was not set :/
            }

            UserInterface.CheckEvents();


            
        }



    }
}
