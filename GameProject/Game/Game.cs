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

namespace GameProject.Game
{
    class GameObj: Frame// game is combined with many elements
    {
        //RectangleShape test = new RectangleShape(new Vector2f(90, 90));

        Player User;
        UserInterface UserInterface;

        public GameObj()
        {
            
        }


        public void SetPlayer(Player userObj)//really important method- game need Player obiect, almost work like constructor
        {
            User = userObj;
            UserInterface = new UserInterface(User);
            //test.FillColor = Color.Cyan;
           
            
        }

        



        public override void CheckEvents(MyWindow window)
        {
            if (User == null)
            {
                throw new Exception();// Player was not set :/
            }

            UserInterface.CheckEvents();


            
        }

        public override void Render(MyWindow window)
        {
            UserInterface.Render();
            //window.Draw(test);
        }

    }
}
