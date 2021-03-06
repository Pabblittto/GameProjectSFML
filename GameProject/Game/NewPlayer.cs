﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using GameProject.Elements;

namespace GameProject.Game
{
    class NewPlayer: Frame// frame to creating new player
    {
        static public Boolean Focus = false;// variable which allow get characers from keyboard
        TextInput NameInput;
        Text Info;
        Sprite Background;
        Button ok;// create new player
        Button back;//back to maenu
        
        

        public NewPlayer(Menu menu)
        {
            
            NameInput = new TextInput(new Vector2f(450, 50), new Vector2f(665, 70), Color.Black);


            Info = new Text("Whats youry name Capitan?", ObjectsBank.MyFont, 40)
            {
                Position = new Vector2f(625, 10),
                Color = Color.Black
            };
            

            ok = new Button(new Vector2f(925, 130), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Adventure!", 30, ObjectsBank.game,1);
            back = new Button(new Vector2f(625, 130), new Vector2f(250, 50), new Color(0, 250, 255), new Color(0, 152, 155), ObjectsBank.MyFont, "Back", 30, menu,1);
            ok.Center();
            back.Center();

            back.AddingAdditionalFunction(FocusChanged);
            ok.AddingAdditionalFunction(FocusChanged);
            ok.AddingAdditionalFunction(CreatePlayer);
            

            Background = new Sprite(Menu.BackSite);
            Background.Color = new Color(255, 255, 255, 128);// semi transparent
        }

        private void Window_TextEntered(object sender, TextEventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Render(MyWindow window)
        {
            Focus = true;
            window.Draw(Background);
            window.Draw(ok);
            window.Draw(back);

            window.Draw(Info);
            NameInput.Draw();
            
        }

        public override void CheckEvents(MyWindow window)
        {
            NameInput.CheckEvents();
        }


        private void FocusChanged()
        {
            NameInput.Clear();
            Focus = false;
        }

        // function for creating player object after clicking
        private void CreatePlayer()
        {
            ok.FutureUser = new Player(NameInput.Content.DisplayedString, Functions.GenerateMap(1), GameObj.BeginnerShip);
        }

    }
}
