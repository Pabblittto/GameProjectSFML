using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.System;
using SFML.Window;
using SFML.Graphics;
using GameProject.Elements;
using System.IO;

namespace GameProject.Elements
{
    class PossibleSave :Drawable // this element will be needed in loading frame- it respersents one saved world there will be 5 in total
    {
        RectangleShape MainContainer;
        Button2 Delete;
        Button2 Play;
        Boolean FoundSave = false;
        

        String PlayerName;// contains player name
        Text NameOfPlayer;// diaplay playesrs name



        public PossibleSave( int row_nr)
        {
            
            MainContainer = new RectangleShape(new Vector2f(800, 100))
            {
                FillColor = new Color(255, 255, 255, 128),
                Origin = new Vector2f(400, 50),
                OutlineThickness = 3,
                OutlineColor = new Color(130, 130, 130),
                Position = new Vector2f(900, row_nr * 150)
            };

            Delete = new Button2(new Vector2f(MainContainer.Position.X + 100, MainContainer.Position.Y-20), new Vector2f(130,50), new Color(0, 250, 255), new Color(0, 152, 155),MyWindow.MyFont,"Delete",30);
            Play = new Button2(new Vector2f(Delete.Shape.Position.X + 150, Delete.Shape.Position.Y), new Vector2f(130, 50), new Color(0, 250, 255), new Color(0, 152, 155), MyWindow.MyFont, "Play", 30);
        }

        public void Update(string name)
        {
            PlayerName = name;
            if (PlayerName != "")// if save actually exist!!
            {
                FoundSave = true;
                PlayerName = PlayerName.Remove(0, 8);
                PlayerName = PlayerName.Remove(PlayerName.Count() - 5,5);


                Delete.setFunction(this.DeleteFunc, PlayerName);
                Play.setFunction(this.PlayFunc, "");

                NameOfPlayer = new Text(PlayerName, MyWindow.MyFont, 50)
                {
                    Color = Color.Black,
                    Origin = new Vector2f(0, 25),
                    Position = new Vector2f(this.MainContainer.Position.X-370,this.MainContainer.Position.Y),
                };
            }
            else
            {
                FoundSave = false;
                NameOfPlayer = new Text("Free slot", MyWindow.MyFont, 70)
                {
                    Color = Color.Black,
                    Origin = new Vector2f(0, 35),
                    Position = new Vector2f(this.MainContainer.Position.X - 370, this.MainContainer.Position.Y),
                };
            }

        }



        public void Draw(RenderTarget window, RenderStates states)
        {
            window.Draw(MainContainer);
            window.Draw(NameOfPlayer);
            if (FoundSave == true)
            {
                window.Draw(Delete);
                window.Draw(Play);
            }


        }
        


        private void DeleteFunc(string a)// string a is useless
        {
            string path = "./Res/Sav/" + a + "G.sav";
            System.IO.File.Delete(path);
            this.Update("");

        }


        private void PlayFunc(string a)// i should think twice about this :/
        {


        }


    }
}
