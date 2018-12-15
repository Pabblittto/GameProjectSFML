using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;

namespace GameProject
{
    class Settings: Frame
    {
        Button Back;
       
        Sprite BackSite;// background Sprite

        public Settings(Sprite FromMenu, Menu menu)
        {
            BackSite =new Sprite(FromMenu);
            BackSite.Color = new Color(255, 255, 255, 128);// semi transparent background
            //Back = new Button(new Vector2f(250, 50), new Vector2f(20, 800), new Color(0, 250, 255), new Color(0, 152, 155), "Back", MyWindow.MyFont,MyWindow.window,menu);
            Back = new Button(new Vector2f(20, 800), new Vector2f(250, 50),new Color(0, 250, 255), new Color(0, 152, 155), MyWindow.MyFont, "Back", 30, menu, 1);

        }



        public override void Render(MyWindow window)
        {
            window.Draw(BackSite);
            window.Draw(Back);
        }

        public override void CheckEvents(MyWindow window)
        {
        }


    }
}
