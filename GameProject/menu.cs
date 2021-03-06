﻿using System;
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


            NewGame = new Button(new Vector2f(20, 20), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "New Game", 30, newPlayer, 1);
            Load = new Button(new Vector2f(20, 90), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Load", 30, loading, 1);
            Options = new Button(new Vector2f(20, 160), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Settings", 30, settings, 1);
            Exit = new Button(new Vector2f(20, 230), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Exit", 30, exit, 1);

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
