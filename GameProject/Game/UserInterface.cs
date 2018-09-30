using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameProject.Elements;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GameProject.Game
{
    class UserInterface// this is the biggest rectangle on left/ Contains all other user interface elements
    {
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
            
            
            User = PlayerObj;
        }

        public void Render()
        {
            MyWindow.window.Draw(AllField);
        }
       
        public void CheckEvents()
        {

        }


    }
}
