using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Elements;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Game.Objects;

namespace GameProject.Game
{
    class UserInterface// this is the biggest rectangle on left/ Contains all other user interface elements
    {
        Cannon cannontest;
        Cargo test;
        CardSlot<Cargo> CargoSlot1;
        CardSlot<Cargo> CargoSlot2;
        RectangleShape AllField;
        Player User;

        
        

        public UserInterface(Player PlayerObj)
        {
            Texture tem = new Texture("Res/UserInt.bmp")
            {
                Repeated = true
            };
            


            AllField = new RectangleShape(new Vector2f(800, 900));
            AllField.Texture = tem;


            CargoSlot1 = new CardSlot<Cargo>(new Vector2f(20, 200), "./Res/Cards/slot.png");
            CargoSlot2 = new CardSlot<Cargo>(new Vector2f(20, 300), "./Res/Cards/slot.png");


            test = new Cargo("./Res/Cards/Wheat.png", "", "Wheat", 35, 1);
            test.SetItemPosition(new Vector2f(10, 10));

            cannontest = new Cannon("./Res/Cards/Cannon.png","Good AF",120,80,10,4);
            cannontest.SetItemPosition(new Vector2f(120, 10));

            User = PlayerObj;
        }

        public void Render()
        {
            MyWindow.window.Draw(AllField);
            MyWindow.window.Draw(CargoSlot1);
            MyWindow.window.Draw(CargoSlot2);

            MyWindow.window.Draw(test);
            MyWindow.window.Draw(cannontest);

        }

        public void CheckEvents()
        {
            test.DrawInfoBox();
            cannontest.DrawInfoBox();

        }


    }
}
