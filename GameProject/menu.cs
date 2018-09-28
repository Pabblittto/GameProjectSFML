using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;


namespace GameProject
{
    class Menu : Frame
    {
        Texture BackImage;
        Sprite BackSite;// background Sprite
        Button Start, Options, Exit;


        public Menu(MyWindow window)
        {
            //C: \Users\Pabblo\Desktop\SFMLProjectC#\GameProject\GameProject\Res\Menu\Image.png
                BackImage = new Texture("./Res/Menu/Image.png");
                BackSite = new Sprite(BackImage);
                Start = new Button(new Vector2f(250, 50), new Vector2f(20, 20), new Color(0, 250, 255), new Color(0, 152, 155), "Start", MyWindow.MyFont,window);
                Options = new Button(new Vector2f(250, 50), new Vector2f(20, 90), new Color(0, 250, 255), new Color(0, 152, 155), "Options", MyWindow.MyFont,window);

        }


        public override void Render(MyWindow window)// function for rendering all obiects only draw in right order
        {
            window.Draw(BackSite);
            Start.Draw(window);
            Options.Draw(window);


        }

        public override void CheckEvents(MyWindow window)// function for checking events
        {
            Start.Functionality();
            Options.Functionality();
        }



    }
}
