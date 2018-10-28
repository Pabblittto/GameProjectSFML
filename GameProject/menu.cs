using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;
using GameProject.Game;


namespace GameProject
{
    class Menu : Frame
    {
        
        
        Texture BackImage;
        public static Sprite BackSite;// background Sprite
        Button NewGame,Load, Options, Exit;
        Settings settings;
        Exit exit = new Exit();// simple object to close game
        NewPlayer newPlayer;
        Loading loading;



        public Menu(MyWindow window)
        {
         
                BackImage = new Texture("Res/Menu/Image.png");
                BackSite = new Sprite(BackImage);
                settings = new Settings(BackSite, this);
                newPlayer = new NewPlayer(this);
                loading = new Loading(BackSite, this);
           

                NewGame = new Button(new Vector2f(250, 50), new Vector2f(20, 20), new Color(0, 250, 255), new Color(0, 152, 155), "New Game", MyWindow.MyFont,window,newPlayer);
                Load = new Button(new Vector2f(250, 50), new Vector2f(20, 90), new Color(0, 250, 255), new Color(0, 152, 155), "Load", MyWindow.MyFont,window,loading);
                Options = new Button(new Vector2f(250, 50), new Vector2f(20, 160), new Color(0, 250, 255), new Color(0, 152, 155), "Settings", MyWindow.MyFont,window,settings);
                Exit = new Button(new Vector2f(250, 50), new Vector2f(20, 230), new Color(0, 250, 255), new Color(0, 152, 155), "Exit", MyWindow.MyFont,window,exit);

            Load.AddingAdditionalFunction(loading.CheckFiles);// this always will check if thetre is a save
            
        }


        public override void Render(MyWindow window)// function for rendering all obiects only draw in right order
        {
            window.Draw(BackSite);
            window.Draw(NewGame);
            window.Draw(Load);
            window.Draw(Options);
            window.Draw(Exit);


        }

        public override void CheckEvents(MyWindow window)// function for checking events
        {

        }



    }
}
