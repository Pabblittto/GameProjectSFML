using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using GameProject.Game;

namespace GameProject.Elements
{
    class TextInput
    {
        public Text Content;
        RectangleShape Shape;



        public TextInput(Vector2f boxSize,Vector2f Position, Color textColor)
        {
            ObjectsBank.window.TextEntered += TextEntering;

            Shape = new RectangleShape(boxSize)
            {
                Position = Position,
                FillColor = Color.White
            };

            Content = new Text("", ObjectsBank.MyFont, (uint)boxSize.Y - 10)
            {
                Color = textColor,
                Position = new Vector2f(Shape.Position.X + 10, Shape.Position.Y + 5)
            };

        }

        private void TextEntering(object sender, TextEventArgs e)
        { 
            if (NewPlayer.Focus == true  )
            {
                if (e.Unicode != "\b")
                {
                    if(Content.DisplayedString.Count() < 15)
                    {
                        Content.DisplayedString += e.Unicode;
                    }
                }
                else
                {
                    if (Content.DisplayedString.Count() != 0)
                    {
                        Content.DisplayedString = Content.DisplayedString.Remove(Content.DisplayedString.Count() - 1, 1);
                    }
                }
                
            }
        }



        public void CheckEvents()
        {
            // maybe possible events with clicking on this input shape
        }


        public void Draw()// method to draw this obiect 
        {
            ObjectsBank.window.Draw(Shape);
            ObjectsBank.window.Draw(Content);
        }

        public void Clear()
        {
            Content.DisplayedString = "";
        }

    }
}
