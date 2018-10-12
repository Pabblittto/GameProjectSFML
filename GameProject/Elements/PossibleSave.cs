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

        }

        public void Update(string name)
        {
            PlayerName = name;
            if (PlayerName != "")// if save actually exist!!
            {
                PlayerName = PlayerName.Remove(0, 8);
                PlayerName = PlayerName.Remove(PlayerName.Count() - 5,5);

                NameOfPlayer = new Text(PlayerName, MyWindow.MyFont, 50)
                {
                    Color = Color.Black,
                    Origin = new Vector2f(0, 25),
                    Position = new Vector2f(this.MainContainer.Position.X-370,this.MainContainer.Position.Y),
                };

            }
            else
            {
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

        }



        private void DeleteFunc()
        {


        }


        private void PlayFunc()// i should think about this :/
        {


        }


    }
}
