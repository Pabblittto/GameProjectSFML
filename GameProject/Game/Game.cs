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
        SFML.Graphics.View UserLeftSite;
        SFML.Graphics.View MapRightSite;
        

        Player User;
        UserInterface UserInterface;
        Map MyMap;


        public GameObj()
        {
            UserLeftSite = new SFML.Graphics.View(new FloatRect(0,0,800,900));
            UserLeftSite.Viewport = new FloatRect(0,0,8/18f,1f);

            MapRightSite = new SFML.Graphics.View(new FloatRect(0,0,1000,900));
            MapRightSite.Viewport = new FloatRect(8 / 18f, 0, 10 / 18f, 1f);
            



        }


        public void SetPlayer(Player userObj)//really important method- game need Player obiect, almost work like constructor
        {
            User = userObj;
            UserInterface = new UserInterface(User);
            MyMap = new Map(userObj);
            MapRightSite.Center = MyMap.ShipPosition;
        }




        public override void Render(MyWindow window)
        {
            window.SetView(UserLeftSite);
            UserInterface.Render();
            UserInterface.CheckEvents();

            window.SetView(MapRightSite);
            MyMap.TilesOnWindow(MapRightSite);
            MyMap.Render();
           
            

        }

        public override void CheckEvents(MyWindow window)// prawdopodobnie to jest nie potrzebne
        {
            if (User == null)
            {
                throw new Exception();// Player was not set :/
            }
            // MainMap.CheckEvents();


            if (Keyboard.IsKeyPressed(Keyboard.Key.Down ))
            {
                MapRightSite.Move(new Vector2f(0, 1));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Up ))
            {
                MapRightSite.Move(new Vector2f(0, -1));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Right ))
            {
                MapRightSite.Move(new Vector2f(1, 0));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.Left ))
            {
                MapRightSite.Move(new Vector2f(-1, 0));
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                MapRightSite.Rotate(1);
            }

            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                MapRightSite.Rotate(-1);
            }



        }



    }
}
