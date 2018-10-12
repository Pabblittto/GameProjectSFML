using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.System;
using SFML.Window;
using SFML.Graphics;

namespace GameProject.Elements
{
    class Button2: Drawable// this button only make one function while clicking , unlucky its almost copied obiect button :/, well ...
    {
        public  delegate void FunctionToDo(string optionally);
        public FunctionToDo Adding;


        Boolean focus = false;
        Text Content;
        RectangleShape Shape;
        Color OnHoverColor, NormalColor;
        string OptionallySTR;

        

        public Button2(Vector2f position, Vector2f size, Color Background,Color OnHover, Font UsedFont,string ToDisplay,uint CharacterSize, FunctionToDo Funct,string OptionallyStr)
        {
            OptionallySTR = OptionallyStr;
            OnHoverColor = OnHover;
            NormalColor = Background;
            Adding += Funct;

            Shape = new RectangleShape(size)
            {
                Position = position,
                FillColor = Background,
                OutlineThickness = 3,
                OutlineColor = Color.Black

            };

            Content = new Text(ToDisplay, UsedFont, CharacterSize)
            {
                Color = Color.Black,
                Position = new Vector2f(Shape.Position.X + 5, Shape.Position.Y + 10)
            };

        }


        private void Onclick()
        {
            if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, MyWindow.window) && Mouse.IsButtonPressed(Mouse.Button.Left))
            {
                Adding(this.OptionallySTR);
            }

        }

        private void WhenHover()
        {
            if (Functions.CheckIfMouseHover(Shape.Size, Shape.Position, MyWindow.window))
            {
                if (focus == false)
                {
                    Shape.FillColor = OnHoverColor;
                    Shape.OutlineColor = new Color(232, 0, 23);
                    focus = true;
                    // add here sound of click
                }
            }
            else
            {
                if (focus == true)
                {
                    Shape.OutlineColor = Color.Black;
                    Shape.FillColor = NormalColor;
                    focus = false;
                }
            }
        }

        public void Draw(RenderTarget window,RenderStates states)
        {
            this.WhenHover();
            this.Onclick();
            window.Draw(Shape);

        }
    }
}
