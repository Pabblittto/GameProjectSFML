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
using GameProject.Game.UsrInt;

namespace GameProject.Game
{
    class UserInterface// this is the biggest rectangle on left/ Contains all other user interface elements
    {
        //Cannon cannontest;
        //Cargo test;
        //Cargo test1;

        //CardSlot<Cargo> CargoSlot1;
        //CardSlot<Cargo> CargoSlot2;


        RectangleShape AllField;
        Player User;
        ShipCrewContainer CrewContainer;
    
        

        public UserInterface(Player PlayerObj)
        {
            Texture temp = new Texture("Res/UserInt.bmp")
            {
                Repeated = true
            };
            
            AllField = new RectangleShape(new Vector2f(800, 900));
            AllField.Texture = temp;


            //CargoSlot1 = new CardSlot<Cargo>(new Vector2f(20, 200), "./Res/Cards/slot.png");
            //CargoSlot2 = new CardSlot<Cargo>(new Vector2f(20, 300), "./Res/Cards/slot.png");


            //test = new Cargo("./Res/Cards/Wheat.png", "", "Wheat", 35, 1);
            //test.SetItemPosition(new Vector2f(10, 10));

            //test1 = new Cargo("./Res/Cards/Wheat.png", "", "Wheat", 31, 2000);
            //test1.SetItemPosition(new Vector2f(300, 10));

            //cannontest = new Cannon("./Res/Cards/Cannon.png","Good AF",120,80,10,4);
            //cannontest.SetItemPosition(new Vector2f(120, 10));

            User = PlayerObj;
            CrewContainer = new ShipCrewContainer(User);
       

        }

        public void Render()
        {

            ObjectsBank.window.Draw(AllField);

            //MyWindow.window.Draw(CargoSlot1);
            //MyWindow.window.Draw(CargoSlot2);
            //MyWindow.window.Draw(test);
            //MyWindow.window.Draw(test1);
            //MyWindow.window.Draw(cannontest);

            ObjectsBank.window.Draw(CrewContainer);

            if(ObjectsBank.MouseIsDragging==true && ObjectsBank.DraggedCard != null)// this if makes draged card more visible
            {
                ObjectsBank.window.Draw(ObjectsBank.DraggedCard);
            }

        }

        public void CheckEvents()
        {


            //test.DrawInfoBox();
            //test1.DrawInfoBox();
            //cannontest.DrawInfoBox();

        }


    }
}
