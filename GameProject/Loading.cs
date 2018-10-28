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
using System.IO;

namespace GameProject
{
    class Loading: Frame
    {
        Button Back;
        Sprite BackGround;

        PossibleSave[] Sav = new PossibleSave[5];

        
        public Loading(Sprite FromMenu, Menu menu)
        {

            for (int i = 0; i < 5; i++)
            {
                Sav[i] = new PossibleSave(1+i);
            }

            BackGround = new Sprite(FromMenu);
            BackGround.Color = new Color(255, 255, 255, 128);// semi transparent background
            Back = new Button(new Vector2f(250, 50), new Vector2f(20, 800), new Color(0, 250, 255), new Color(0, 152, 155), "Back", MyWindow.MyFont, MyWindow.window, menu);

        }

        public void CheckFiles()// this function is runned when sb click on the load button in menu
        {
            string folder = "Res/Sav";
            string files = @"*G.sav";
            string[] filelist = Directory.GetFiles(folder, files);

            for (int i = 0; i < 5; i++)
            {
                try
                {
                        Sav[i].Update(filelist[i]);
                    
                }catch(IndexOutOfRangeException e)
                {
                    Sav[i].Update("");
                }
            }

        }


        public override void CheckEvents(MyWindow window)
        {

        }

        public override void Render(MyWindow window)
        {

            window.Draw(BackGround);
            window.Draw(Back);


            for (int i = 0; i < 5; i++)
            {
                window.Draw(Sav[i]);
            }
        }

    }
}
